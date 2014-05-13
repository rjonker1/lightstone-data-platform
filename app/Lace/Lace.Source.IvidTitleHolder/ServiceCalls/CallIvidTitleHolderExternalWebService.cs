using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Common.Logging;
using Lace.Functions.Json;
using Lace.Models.IvidTitleHolder;
using Lace.Request;
using Lace.Response;
using Lace.Source.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Source.IvidTitleHolder.ServiceConfig;
using Lace.Source.IvidTitleHolder.Transform;

namespace Lace.Source.IvidTitleHolder.ServiceCalls
{
    public class CallIvidTitleHolderExternalWebService : ICallTheExternalWebService
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private TitleholderQueryResponse _ividTitleHolderResponse;
        private readonly ILaceRequest _request;

        public CallIvidTitleHolderExternalWebService(ILaceRequest request)
        {
            _request = request;
        }

        public void CallTheExternalWebService(ILaceResponse response)
        {
            try
            {
                Log.Info("Calling Ivid Title Holder Web Service");

                var ividTitleHolderWebService = new ConfigureIvidTitleHolderWebService();

                ividTitleHolderWebService.ConfigureIvidTitleHolderServiceCredentials();
                ividTitleHolderWebService.ConfigureIvidTitleHolderWebServiceRequestMessageProperty();

                using (var scope = new OperationContextScope(ividTitleHolderWebService.IvidTitleHolderProxy.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ividTitleHolderWebService.IvidTitleHolderRequestMessageProperty;

                    var ividTitleHolderRequest = new ConfigureIvidTitleHolderRequestMessage(_request)
                        .TitleholderQueryRequest;

                    _ividTitleHolderResponse = ividTitleHolderWebService
                        .IvidTitleHolderProxy
                        .TitleholderQuery(ividTitleHolderRequest);

                    ividTitleHolderWebService
                        .CloseWebService();

                   
                    TransformWebResponse(response);
                }

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Ivid Title Holder Web Service {0}", ex.Message);
                IvidTitleHolderResponseFailed(response);
                throw;
            }
        }

        private static void IvidTitleHolderResponseFailed(ILaceResponse response)
        {
            response.IvidTitleHolderResponse = null;
            response.IvidTitleHolderResponseHandled = new IvidTitleHolderResponseHandled();
            response.IvidTitleHolderResponseHandled.HasBeenHandled();
        }
        
        private void LogServiceResponse()
        {
            Log.InfoFormat("Response Received from Ivid Title Holder Web Service {0}", JsonFunctions.JsonFunction.ObjectToJson(_ividTitleHolderResponse));
        }

        public void TransformWebResponse(ILaceResponse response)
        {
            var transformer = new TransformIvidTitleHolderWebResponse(_ividTitleHolderResponse);

            if (transformer.Continue)
            {
                LogServiceResponse();
                transformer.Transform();
            }

            response.IvidTitleHolderResponse = transformer.Result;
            response.IvidTitleHolderResponseHandled = new IvidTitleHolderResponseHandled();
            response.IvidTitleHolderResponseHandled.HasBeenHandled();
        }
    }
}
