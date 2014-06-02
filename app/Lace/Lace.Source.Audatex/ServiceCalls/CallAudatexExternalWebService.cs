using System;
using Common.Logging;
using Lace.Events;
using Lace.Functions.Json;
using Lace.Models.Audatex;
using Lace.Request;
using Lace.Response;
using Lace.Source.Audatex.AudatexServiceReference;
using Lace.Source.Audatex.ServiceConfig;
using Lace.Source.Audatex.Transform;
using Monitoring.Sources;

namespace Lace.Source.Audatex.ServiceCalls
{
    public class CallAudatexExternalWebService : ICallTheExternalWebService
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private GetDataResult _audatexResponse;
        private readonly ILaceRequest _request;
        private const FromSource Source = FromSource.AudatexSource;

        public CallAudatexExternalWebService(ILaceRequest request)
        {
            _request = request;
        }

        public void CallTheExternalWebService(ILaceResponse response, ILaceEvent laceEvent)
        {
            try
            {
                laceEvent.PublishStartServiceConfigurationMessage(_request.User.AggregateId, Source);

                var audatexWebService = new ConfigureAudatexWebService();
                var audatexRequest = new ConfigureAudatexRequestMessage(_request)
                    .AudatexRequest;
                var credentials = new ConfigureAudatexCredentials().Credentials;

                laceEvent.PublishEndServiceConfigurationMessage(_request.User.AggregateId, Source);

                laceEvent.PublishServiceRequestMessage(_request.User.AggregateId, Source,
                       JsonFunctions.JsonFunction.ObjectToJson(audatexRequest));

                laceEvent.PublishStartServiceCallMessage(_request.User.AggregateId, Source);

                _audatexResponse = audatexWebService
                    .AudatexServiceProxy
                    .GetDataEx(credentials, audatexRequest.MessageType, audatexRequest.Message, 0);

                laceEvent.PublishEndServiceCallMessage(_request.User.AggregateId, Source);

                audatexWebService.CloseWebService();

                if (_audatexResponse == null)
                    laceEvent.PublishNoResponseFromServiceMessage(_request.User.AggregateId, Source);

                laceEvent.PublishServiceResponseMessage(_request.User.AggregateId, Source,
                        JsonFunctions.JsonFunction.ObjectToJson(_audatexResponse ?? new GetDataResult()));

                TransformWebResponse(response);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Audatex Web Service {0}", ex.Message);
                laceEvent.PublishFailedServiceCallMessaage(_request.User.AggregateId, Source);
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
               transformer.Transform();
            }

            response.AudatexResponse = transformer.Result;
            response.AudatexResponseHandled = new AudatexResponseHandled();
            response.AudatexResponseHandled.HasBeenHandled();
        }
    }
}
