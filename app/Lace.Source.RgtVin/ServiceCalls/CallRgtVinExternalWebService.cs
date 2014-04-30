using System;
using Common.Logging;
using Lace.Models.RgtVin;
using Lace.Models.RgtVin.Dto;
using Lace.Request;
using Lace.Response;
using Lace.Source.RgtVin.ServiceConfig;
using Lace.Source.RgtVin.Transform;

namespace Lace.Source.RgtVin.ServiceCalls
{
    public class CallRgtVinExternalWebService : ICallTheExternalWebService
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private string _rgtVinResponse;

        public void CallTheExternalWebService(ILaceRequest request, ILaceResponse response)
        {
            try
            {
                var rgtVinWebService = new ConfigureRgtVinWebService();
                var rgtVinRequest = new ConfigureRgtVinRequestMessage(request)
                    .RgtVinRequest;


                LogServiceRequest(rgtVinRequest);

                _rgtVinResponse = rgtVinWebService
                    .RgtVinServiceProxy
                    .VinCheckAlt(rgtVinRequest.Vin, rgtVinRequest.SecurityCode);

                rgtVinWebService.CloseWebService();

                if (string.IsNullOrEmpty(_rgtVinResponse))
                    Log.Error("Response from RGT Vin Web Service is null or does not exist.");

                TransformWebResponse(response);

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling RGT Vin Web Service {0}", ex.Message);
                RgtVinResponseFailed(response);
            }
        }

        public void TransformWebResponse(ILaceResponse response)
        {
            var transformer = new TransformRgtVinWebResponse(_rgtVinResponse);

            if (transformer.Continue)
            {
                LogServiceResponse();
                transformer.Transform();
            }

            response.RgtVinResponse = transformer.Result;
            response.RgtVinResponseHandled = new RgtVinResponseHandled();
            response.RgtVinResponseHandled.HasBeenHandled();
        }

        private static void RgtVinResponseFailed(ILaceResponse response)
        {
            response.RgtVinResponse = null;
            response.RgtVinResponseHandled = new RgtVinResponseHandled();
            response.RgtVinResponseHandled.HasBeenHandled();
        }

        private static void LogServiceRequest(RgtVinRequest request)
        {
            Log.InfoFormat("RGT Request sent to RGT Vin Web Service: {0}", Helpers.JsonFunctions.ObjectToJson(request));
        }

        private void LogServiceResponse()
        {
            Log.InfoFormat("Response Received from RGT Vin Web Service {0}",
                Helpers.JsonFunctions.ObjectToJson(_rgtVinResponse));
        }
    }
}
