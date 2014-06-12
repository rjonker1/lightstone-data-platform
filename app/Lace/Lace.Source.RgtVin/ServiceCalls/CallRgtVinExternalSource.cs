using System;
using System.Data;
using Common.Logging;
using Lace.Events;
using Lace.Functions.Json;
using Lace.Models.RgtVin;
using Lace.Request;
using Lace.Response;
using Lace.Source.RgtVin.ServiceConfig;
using Lace.Source.RgtVin.Transform;
using Monitoring.Sources.Lace;

namespace Lace.Source.RgtVin.ServiceCalls
{
    public class CallRgtVinExternalSource : ICallTheExternalSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private DataSet _rgtVinResponse;
        private readonly ILaceRequest _request;
        private const ExternalSource Source = ExternalSource.RgtVinSource;

        public CallRgtVinExternalSource(ILaceRequest request)
        {
            _request = request;
        }

        public void CallTheExternalWebService(ILaceResponse response, ILaceEvent laceEvent)
        {
            try
            {
                laceEvent.PublishStartServiceConfigurationMessage(_request.RequestAggregation.AggregateId, Source);

                var rgtVinWebService = new ConfigureRgtVinWebSource();
                var rgtVinRequest = new ConfigureRgtVinRequestMessage(_request)
                    .RgtVinRequest;

                laceEvent.PublishEndServiceConfigurationMessage(_request.RequestAggregation.AggregateId, Source);

                laceEvent.PublishServiceRequestMessage(_request.RequestAggregation.AggregateId, Source,
                       JsonFunctions.JsonFunction.ObjectToJson(rgtVinRequest));


                laceEvent.PublishStartServiceCallMessage(_request.RequestAggregation.AggregateId, Source);

                _rgtVinResponse = rgtVinWebService
                    .RgtVinServiceProxy
                    .VinCheckSpecsFiltered(rgtVinRequest.Vin, string.Empty, rgtVinRequest.SecurityCode);

                laceEvent.PublishEndServiceCallMessage(_request.RequestAggregation.AggregateId, Source);


                rgtVinWebService.CloseWebService();

                if (_rgtVinResponse == null)
                    laceEvent.PublishNoResponseFromServiceMessage(_request.RequestAggregation.AggregateId, Source);

                laceEvent.PublishServiceResponseMessage(_request.RequestAggregation.AggregateId, Source,
                        JsonFunctions.JsonFunction.ObjectToJson(_rgtVinResponse ?? new DataSet()));

                TransformWebResponse(response);

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling RGT Vin Web Service {0}", ex.Message);
                laceEvent.PublishFailedServiceCallMessaage(_request.RequestAggregation.AggregateId, Source);
                RgtVinResponseFailed(response);
            }
        }

        public void TransformWebResponse(ILaceResponse response)
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

        private static void RgtVinResponseFailed(ILaceResponse response)
        {
            response.RgtVinResponse = null;
            response.RgtVinResponseHandled = new RgtVinResponseHandled();
            response.RgtVinResponseHandled.HasBeenHandled();
        }

    }
}
