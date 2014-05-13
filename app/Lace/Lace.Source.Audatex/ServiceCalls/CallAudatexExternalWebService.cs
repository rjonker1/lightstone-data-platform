using System;
using Common.Logging;
using Lace.Functions.Json;
using Lace.Models.Audatex;
using Lace.Models.Audatex.Dto;
using Lace.Request;
using Lace.Response;
using Lace.Source.Audatex.AudatexServiceReference;
using Lace.Source.Audatex.ServiceConfig;
using Lace.Source.Audatex.Transform;

namespace Lace.Source.Audatex.ServiceCalls
{
    public class CallAudatexExternalWebService : ICallTheExternalWebService
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private GetDataResult _audatexResponse;
        private readonly ILaceRequest _request;

        public CallAudatexExternalWebService(ILaceRequest request)
        {
            _request = request;
        }

        public void CallTheExternalWebService(ILaceResponse response)
        {
            try
            {
                Log.Info("Calling Audatex Web Service");

                var audatexWebService = new ConfigureAudatexWebService();
                var audatexRequest = new ConfigureAudatexRequestMessage(_request)
                    .AudatexRequest;
                var credentials = new ConfigureAudatexCredentials().Credentials;

                LogServiceRequest(audatexRequest);

                _audatexResponse = audatexWebService
                    .AudatexServiceProxy
                    .GetDataEx(credentials, audatexRequest.MessageType, audatexRequest.Message, 0);

                audatexWebService.CloseWebService();

                if (_audatexResponse == null)
                    Log.Error("Response from Audatex Web Service is null or does not exist.");

                TransformWebResponse(response);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Audatex Web Service {0}", ex.Message);
                AudatexResponseFailed(response);
            }
        }

        private static void AudatexResponseFailed(ILaceResponse response)
        {
            response.AudatexResponse = null;
            response.AudatexResponseHandled = new AudatexResponseHandled();
            response.AudatexResponseHandled.HasBeenHandled();
        }

        public void TransformWebResponse(ILaceResponse response)
        {
            var transformer = new TransformAudatexWebResponse(_audatexResponse, response, _request);

            if (transformer.Continue)
            {
                LogServiceResponse();
                transformer.Transform();
            }

            response.AudatexResponse = transformer.Result;
            response.AudatexResponseHandled = new AudatexResponseHandled();
            response.AudatexResponseHandled.HasBeenHandled();
        }

        private static void LogServiceRequest(AudatexRequest request)
        {
            Log.InfoFormat("Audatex Request sent to Audatex Web Service: {0}", JsonFunctions.JsonFunction.ObjectToJson(request));
        }

        private void LogServiceResponse()
        {
            Log.InfoFormat("Response Received from Audatex Web Service {0}", JsonFunctions.JsonFunction.ObjectToJson(_audatexResponse));
        }
    }
}
