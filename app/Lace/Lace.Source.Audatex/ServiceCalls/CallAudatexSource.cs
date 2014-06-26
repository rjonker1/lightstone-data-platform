using System;
using Common.Logging;
using Lace.Events;
using Lace.Extensions;
using Lace.Models.Audatex;
using Lace.Request;
using Lace.Response;
using Lace.Source.Audatex.AudatexServiceReference;
using Lace.Source.Audatex.ServiceConfig;
using Lace.Source.Audatex.Transform;
using Monitoring.Sources.Lace;

namespace Lace.Source.Audatex.ServiceCalls
{
    public class CallAudatexSource : ICallTheSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private GetDataResult _audatexResponse;
        private readonly ILaceRequest _request;
        private const LaceEventSource Source = LaceEventSource.Audatex;

        public CallAudatexSource(ILaceRequest request)
        {
            _request = request;
        }

        public void CallTheExternalWebService(ILaceResponse response, ILaceEvent laceEvent)
        {
            try
            {
                laceEvent.PublishStartServiceConfigurationMessage(_request.RequestAggregation.AggregateId, Source);

                var audatexWebService = new ConfigureAudatexSource();
                var audatexRequest = new ConfigureAudatexRequestMessage(_request)
                    .AudatexRequest;
                var credentials = new ConfigureAudatexCredentials().Credentials;

                laceEvent.PublishEndServiceConfigurationMessage(_request.RequestAggregation.AggregateId, Source);

                laceEvent.PublishServiceRequestMessage(_request.RequestAggregation.AggregateId, Source,
                      audatexRequest.ObjectToJson());

                laceEvent.PublishStartServiceCallMessage(_request.RequestAggregation.AggregateId, Source);

                _audatexResponse = audatexWebService
                    .AudatexServiceProxy
                    .GetDataEx(credentials, audatexRequest.MessageType, audatexRequest.Message, 0);

                laceEvent.PublishEndServiceCallMessage(_request.RequestAggregation.AggregateId, Source);

                audatexWebService.CloseWebService();

                if (_audatexResponse == null)
                    laceEvent.PublishNoResponseFromServiceMessage(_request.RequestAggregation.AggregateId, Source);

                laceEvent.PublishServiceResponseMessage(_request.RequestAggregation.AggregateId, Source,
                    _audatexResponse != null ? _audatexResponse.ObjectToJson() : new GetDataResult().ObjectToJson());

                TransformWebResponse(response);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Audatex Web Service {0}", ex.Message);
                laceEvent.PublishFailedServiceCallMessaage(_request.RequestAggregation.AggregateId, Source);
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
            var transformer = new TransformAudatexResponse(_audatexResponse, response, _request);

            if (transformer.Continue)
            {
               transformer.Transform();
            }

            response.AudatexResponse = transformer.Result;
            response.AudatexResponseHandled = new AudatexResponseHandled();
            response.AudatexResponseHandled.HasBeenHandled();
        }
    }
}
