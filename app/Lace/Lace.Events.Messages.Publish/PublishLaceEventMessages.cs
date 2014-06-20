using System;
using Common.Logging;
using System.Threading.Tasks;
using DataPlatform.Shared.Messaging;
using Monitoring.Consumer.Lace.Messages;
using Monitoring.Sources.Lace;
using Workflow;

namespace Lace.Events.Messages.Publish
{
    public class PublishLaceEventMessages : ILaceEvent
    {
        private readonly IPublishMessages _publishMessages;
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        public PublishLaceEventMessages(IPublishMessages publishMessages)
        {
            _publishMessages = publishMessages;
        }

        public void PublishMessage(Guid aggerateId, string message, LaceEventSource source)
        {
            var msg = new LaceEventMessage(aggerateId, source, message);
            PublishMessage(msg);
        }


        public void PublishLaceReceivedRequestMessage(Guid aggregateId, LaceEventSource source)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, source, PublishableLaceMessages.LaceReceivedRequestStarted());
            PublishMessage(message);
        }

        public void PublishLaceProcessedRequestAndReturnedResponseMessage(Guid aggregateId, LaceEventSource source)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, source, PublishableLaceMessages.LaceProcessedRequestAndResturnedResponse());
            PublishMessage(message);
        }

        public void PublishLaceRequestWasNotProcessedAndErrorHasBeenLoggedMessage(Guid aggregateId, LaceEventSource source)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, source,
                PublishableLaceMessages.LaceCannotProcessRequestAndErrorHasBeenLogged());
            PublishMessage(message);
        }


        public void PublishStartServiceCallMessage(Guid aggerateId, LaceEventSource source)
        {
            var msg = new LaceExternalSourceEventMessage(aggerateId, source, PublishableLaceMessages.StartCallingExternalSource());
            PublishMessage(msg);
        }

        public void PublishStartServiceConfigurationMessage(Guid aggerateId, LaceEventSource source)
        {
            var msg = new LaceExternalSourceConfigurationEventMessage(aggerateId, source,
               PublishableLaceMessages.StartConfigurationForExternalSource());
            PublishMessage(msg);
        }

        public void PublishEndServiceConfigurationMessage(Guid aggerateId, LaceEventSource source)
        {
            var msg = new LaceExternalSourceConfigurationEventMessage(aggerateId, source,
                PublishableLaceMessages.EndConfigurationForExternalSource());
            PublishMessage(msg);
        }

        public void PublishEndServiceCallMessage(Guid aggerateId, LaceEventSource source)
        {
            var msg = new LaceExternalSourceEventMessage(aggerateId, source, PublishableLaceMessages.EndCallingExternalSource());
            PublishMessage(msg);
        }

        public void PublishFailedServiceCallMessaage(Guid aggerateId, LaceEventSource source)
        {
            var msg = new LaceExternalSourceFailedEventMessage(aggerateId, source, PublishableLaceMessages.ExternalSourceCallFailed());
            PublishMessage(msg);
        }

        public void PublishNoResponseFromServiceMessage(Guid aggerateId, LaceEventSource source)
        {
            var msg = new LaceExternalSourceNoResponseEventMessage(aggerateId, source,
                PublishableLaceMessages.NoResponseReceivedFromExternalSource());
            PublishMessage(msg);
        }

        public void PublishServiceRequestMessage(Guid aggerateId, LaceEventSource source, string request)
        {
            var msg = new LaceExternalSourceRequestEventMessage(aggerateId, source, PublishableLaceMessages.RequestSentToExternalSource(),
                request);
            PublishMessage(msg);

        }

        public void PublishServiceResponseMessage(Guid aggerateId, LaceEventSource source, string response)
        {
            var msg = new LaceExternalSourceResponseEventMessage(aggerateId, source,
                PublishableLaceMessages.ResponseReceivedFromExternalSource(), response);
            PublishMessage(msg);
        }


        public void PublishSourceIsBeingHandledMessage(Guid aggerateId, LaceEventSource source)
        {
            var msg = new LaceSourceHandledEventMessage(aggerateId, source, PublishableLaceMessages.ExternalSourceIsBeingHandled());
            PublishMessage(msg);
        }

        public void PublishSourceIsNotBeingHandledMessage(Guid aggerateId, LaceEventSource source)
        {
            var msg = new LaceSourceHandledEventMessage(aggerateId, source, PublishableLaceMessages.ExternalSourceIsNotBeingHandled());
            PublishMessage(msg);
        }

        public void PublishTransformationStartMessage(Guid aggerateId, LaceEventSource source)
        {
            var msg = new LaceTransformResponseEventMessage(aggerateId, source,
                PublishableLaceMessages.TransformingResponseFromExternalSourceHasStarted());
            PublishMessage(msg);
        }

        public void PublishTransformationEndMessage(Guid aggerateId, LaceEventSource source)
        {
            var msg = new LaceTransformResponseEventMessage(aggerateId, source, PublishableLaceMessages.TransformingResponseFromExternalSourceHasFinished());
            PublishMessage(msg);
        }

        public void PublishTransformationFailedMessage(Guid aggerateId, LaceEventSource source)
        {
            var msg = new LaceTransformResponseEventMessage(aggerateId, source,
                PublishableLaceMessages.TransformingResponseFromExternalSourceHasFailed());
            PublishMessage(msg);
        }


        public void PublishMessage<T>(T message) where T : class, IPublishableMessage
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    _publishMessages.Publish(message);
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("Error Publishing message to Lace Event Queue: {0}", ex.Message);
                }
            }
                );
        }
    }
}
