using System;
using Common.Logging;
using EventTracking.Sources;
using Lace.Events;
using Lace.Functions.Json;
using Lace.Models.RgtVin;
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
        private readonly ILaceRequest _request;
        private const FromSource Source = FromSource.RgtVinSource;

        public CallRgtVinExternalWebService(ILaceRequest request)
        {
            _request = request;
        }

        public void CallTheExternalWebService(ILaceResponse response, ILaceEvent laceEvent)
        {
            try
            {
                laceEvent.PublishStartServiceConfigurationMessage(_request.Token, Source);

                var rgtVinWebService = new ConfigureRgtVinWebService();
                var rgtVinRequest = new ConfigureRgtVinRequestMessage(_request)
                    .RgtVinRequest;

                laceEvent.PublishEndServiceConfigurationMessage(_request.Token, Source);

                laceEvent.PublishServiceRequestMessage(_request.Token, Source,
                       JsonFunctions.JsonFunction.ObjectToJson(rgtVinRequest));


                laceEvent.PublishStartServiceCallMessage(_request.Token, Source);

                _rgtVinResponse = rgtVinWebService
                    .RgtVinServiceProxy
                    .VinCheckAlt(rgtVinRequest.Vin, rgtVinRequest.SecurityCode);

                laceEvent.PublishEndServiceCallMessage(_request.Token, Source);


                rgtVinWebService.CloseWebService();

                if (string.IsNullOrEmpty(_rgtVinResponse))
                    laceEvent.PublishNoResponseFromServiceMessage(_request.Token, Source);

                laceEvent.PublishServiceResponseMessage(_request.Token, Source,
                        JsonFunctions.JsonFunction.ObjectToJson(_rgtVinResponse ?? string.Empty));

                TransformWebResponse(response);

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling RGT Vin Web Service {0}", ex.Message);
                laceEvent.PublishFailedServiceCallMessaage(_request.Token, Source);
                RgtVinResponseFailed(response);
            }
        }

        public void TransformWebResponse(ILaceResponse response)
        {
            var transformer = new TransformRgtVinWebResponse(_rgtVinResponse);

            if (transformer.Continue)
            {
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

    }
}
