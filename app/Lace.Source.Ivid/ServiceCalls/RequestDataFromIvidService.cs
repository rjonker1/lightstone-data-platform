using System;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Common.Logging;
using Lace.Models.Ivid;
using Lace.Models.Ivid.Dto;
using Lace.Request;
using Lace.Response;
using Lace.Source.Ivid.IvidServiceReference;
using Lace.Source.Ivid.ServiceSetup;
using Lace.Source.Ivid.Transform;

namespace Lace.Source.Ivid.ServiceCalls
{
    public class RequestDataFromIvidService : IRequestDataFromService
    {
        private static readonly ILog Log = LogManager.GetLogger<RequestDataFromIvidService>();

        private ILaceRequest _request;
        private HpiStandardQueryResponse _ividResponse;

        public void FetchDataFromService(ILaceRequest request, ILaceResponse response)
        {
            _request = request;
            
            CallIvidWebService();
            TransformWebResponse(response);
        }


        private void CallIvidWebService()
        {
            try
            {
                Log.Info("Calling Ivid Web Service");

                var ividWebService = new SetupIvidWebService();

                ividWebService.SetupIvidWebServiceCredentials();
                ividWebService.SetupIvidWebServiceRequestMessageProperty();

                using (var scope = new OperationContextScope(ividWebService.IvidServiceProxy.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ividWebService.IvidRequestMessageProperty;

                    var ividRequest = new SetupIvidQueryRequestMessage(_request)
                        .HpiQueryRequest;

                    LogServiceRequest(ividRequest);

                    _ividResponse = ividWebService
                        .IvidServiceProxy
                        .HpiStandardQuery(ividRequest);

                    if (_ividResponse == null || !_ividResponse.partialResponse)
                        Log.Error("Response from Ivid Web Service is null or does not exist.");
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Ivid Web Service {0}", ex.Message);
                //throw;
            }
            
        }

        private static void LogServiceRequest(HpiStandardQueryRequest request)
        {
            Log.InfoFormat("Ivid Request sent to Ivid Web Service: {0}", Helpers.XmlFunctions.ObjectToXml(request));
        }

        private void LogServiceResponse()
        {
            Log.InfoFormat("Response Received from Ivid Web Service {0}", Helpers.XmlFunctions.ObjectToXml(_ividResponse));
        }

        private void TransformWebResponse(ILaceResponse response)
        {
            var transformer = new TransformIvidWebResponse(_ividResponse);

            if (transformer.Continue)
            {
                LogServiceResponse();
                transformer.Transform();
            }

            response.IvidResponse = transformer.Result;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasBeenHandled();
        }
    }
}
