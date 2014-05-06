using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Common.Logging;
using Lace.Models.Ivid;
using Lace.Request;
using Lace.Response;
using Lace.Source.Ivid.IvidServiceReference;
using Lace.Source.Ivid.ServiceConfig;
using Lace.Source.Ivid.Transform;

namespace Lace.Source.Ivid.ServiceCalls
{
    public class CallIvidExternalWebService : ICallTheExternalWebService
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private HpiStandardQueryResponse _ividResponse;
        private readonly ILaceRequest _request;

        public CallIvidExternalWebService(ILaceRequest request)
        {
            _request = request;
        }

        public void CallTheExternalWebService(ILaceResponse response)
        {
            try
            {
                Log.Info("Calling Ivid Web Service");

                var ividWebService = new ConfigureIvidWebService();

                ividWebService.ConfigureIvidWebServiceCredentials();
                ividWebService.ConfigureIvidWebServiceRequestMessageProperty();

                using (var scope = new OperationContextScope(ividWebService.IvidServiceProxy.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ividWebService.IvidRequestMessageProperty;

                    var ividRequest = new ConfigureIvidRequestMessage(_request)
                        .HpiQueryRequest;

                    LogServiceRequest(ividRequest);

                    _ividResponse = ividWebService
                        .IvidServiceProxy
                        .HpiStandardQuery(ividRequest);

                    ividWebService.CloseWebService();

                    if (_ividResponse == null)
                        Log.Error("Response from Ivid Web Service is null or does not exist.");

                    TransformWebResponse(response);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Ivid Web Service {0}", ex.Message);
                IvidResponseFailed(response);
            }
        }

        private static void LogServiceRequest(HpiStandardQueryRequest request)
        {
            Log.InfoFormat("Ivid Request sent to Ivid Web Service: {0}", Helpers.JsonFunctions.ObjectToJson(request));
        }

        private void LogServiceResponse()
        {
            Log.InfoFormat("Response Received from Ivid Web Service {0}", Helpers.JsonFunctions.ObjectToJson(_ividResponse));
        }

        private static void IvidResponseFailed(ILaceResponse response)
        {
            response.IvidResponse = null;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasBeenHandled();
        }

        public void TransformWebResponse(ILaceResponse response)
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
