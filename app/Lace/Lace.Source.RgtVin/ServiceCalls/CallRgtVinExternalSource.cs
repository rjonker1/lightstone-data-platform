using System;
using System.Data;
using Common.Logging;
using Lace.Events;
using Lace.Extensions;
using Lace.Models;
using Lace.Models.RgtVin;
using Lace.Request;
using Lace.Source.RgtVin.ServiceConfig;
using Lace.Source.RgtVin.Transform;
using Monitoring.Sources.Lace;

namespace Lace.Source.RgtVin.ServiceCalls
{
    public class CallRgtVinExternalSource : ICallTheSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private DataSet _rgtVinResponse;
        private readonly ILaceRequest _request;
        private const LaceEventSource Source = LaceEventSource.RgtVin;

        public CallRgtVinExternalSource(ILaceRequest request)
        {
            _request = request;
        }

        public void CallTheExternalSource(IProvideLaceResponse response, ILaceEvent laceEvent)
        {
            try
            {
                laceEvent.PublishStartSourceConfigurationMessage(Source);

                var rgtVinWebService = new ConfigureRgtVinWebSource();
                var rgtVinRequest = new ConfigureRgtVinRequestMessage(_request, response)
                    .Build()
                    .RgtVinRequest;

                laceEvent.PublishEndSourceConfigurationMessage(Source);

                laceEvent.PublishSourceRequestMessage(Source,
                    rgtVinRequest.ObjectToJson());


                laceEvent.PublishStartSourceCallMessage(Source);

                _rgtVinResponse = rgtVinWebService
                    .RgtVinServiceProxy
                    .VinCheckSpecsFiltered(rgtVinRequest.Vin, string.Empty, rgtVinRequest.SecurityCode);

                laceEvent.PublishEndSourceCallMessage(Source);


                rgtVinWebService.CloseWebService();

                if (_rgtVinResponse == null)
                    laceEvent.PublishNoResponseFromSourceMessage(Source);

                laceEvent.PublishSourceResponseMessage(Source,
                    _rgtVinResponse != null ? _rgtVinResponse.ObjectToJson() : new DataSet().ObjectToJson());

                TransformResponse(response);

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling RGT Vin Web Service {0}", ex.Message);
                laceEvent.PublishFailedSourceCallMessage(Source);
                RgtVinResponseFailed(response);
            }
        }

        public void TransformResponse(IProvideLaceResponse response)
        {
            var transformer = new TransformRgtVinResponse(_rgtVinResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.RgtVinResponse = transformer.Result;
            response.RgtVinResponseHandled = new RgtVinResponseHandled();
            response.RgtVinResponseHandled.HasBeenHandled();
        }

        private static void RgtVinResponseFailed(IProvideLaceResponse response)
        {
            response.RgtVinResponse = null;
            response.RgtVinResponseHandled = new RgtVinResponseHandled();
            response.RgtVinResponseHandled.HasBeenHandled();
        }

    }
}
