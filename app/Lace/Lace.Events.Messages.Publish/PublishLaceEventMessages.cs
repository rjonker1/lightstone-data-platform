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
        private readonly Guid _aggerateId;

        public PublishLaceEventMessages(IPublishMessages publishMessages, Guid aggerateId)
        {
            _publishMessages = publishMessages;
            _aggerateId = aggerateId;
        }

        public void PublishMessage(string message, LaceEventSource source)
        {
            var msg = new LaceEventMessage(_aggerateId, source, message);
            PublishMessage(msg);
        }


        public void PublishLaceReceivedRequestMessage(LaceEventSource source)
        {
            var message = new LaceExternalSourceEventMessage(_aggerateId, source,
                PublishableLaceMessages.LaceReceivedRequestStarted());
            PublishMessage(message);
        }

        public void PublishLaceProcessedRequestAndReturnedResponseMessage(LaceEventSource source)
        {
            var message = new LaceExternalSourceEventMessage(_aggerateId, source,
                PublishableLaceMessages.LaceProcessedRequestAndResturnedResponse());
            PublishMessage(message);
        }

        public void PublishLaceRequestWasNotProcessedAndErrorHasBeenLoggedMessage(LaceEventSource source)
        {
            var message = new LaceExternalSourceEventMessage(_aggerateId, source,
                PublishableLaceMessages.LaceCannotProcessRequestAndErrorHasBeenLogged());
            PublishMessage(message);
        }


        public void PublishStartServiceCallMessage(LaceEventSource source)
        {
            var msg = new LaceExternalSourceEventMessage(_aggerateId, source,
                PublishableLaceMessages.StartCallingExternalSource());
            PublishMessage(msg);
        }

        public void PublishStartServiceConfigurationMessage(LaceEventSource source)
        {
            var msg = new LaceExternalSourceConfigurationEventMessage(_aggerateId, source,
                PublishableLaceMessages.StartConfigurationForExternalSource());
            PublishMessage(msg);
        }

        public void PublishEndServiceConfigurationMessage(LaceEventSource source)
        {
            var msg = new LaceExternalSourceConfigurationEventMessage(_aggerateId, source,
                PublishableLaceMessages.EndConfigurationForExternalSource());
            PublishMessage(msg);
        }

        public void PublishEndServiceCallMessage(LaceEventSource source)
        {
            var msg = new LaceExternalSourceEventMessage(_aggerateId, source,
                PublishableLaceMessages.EndCallingExternalSource());
            PublishMessage(msg);
        }

        public void PublishFailedServiceCallMessaage(LaceEventSource source)
        {
            var msg = new LaceExternalSourceFailedEventMessage(_aggerateId, source,
                PublishableLaceMessages.ExternalSourceCallFailed());
            PublishMessage(msg);
        }

        public void PublishNoResponseFromServiceMessage(LaceEventSource source)
        {
            var msg = new LaceExternalSourceNoResponseEventMessage(_aggerateId, source,
                PublishableLaceMessages.NoResponseReceivedFromExternalSource());
            PublishMessage(msg);
        }

        public void PublishServiceRequestMessage(LaceEventSource source, string request)
        {
            var msg = new LaceExternalSourceRequestEventMessage(_aggerateId, source,
                PublishableLaceMessages.RequestSentToExternalSource(),
                request);
            PublishMessage(msg);

        }

        public void PublishServiceResponseMessage(LaceEventSource source, string response)
        {
            var msg = new LaceExternalSourceResponseEventMessage(_aggerateId, source,
                PublishableLaceMessages.ResponseReceivedFromExternalSource(), response);
            PublishMessage(msg);
        }


        public void PublishSourceIsBeingHandledMessage(LaceEventSource source)
        {
            var msg = new LaceSourceHandledEventMessage(_aggerateId, source,
                PublishableLaceMessages.ExternalSourceIsBeingHandled());
            PublishMessage(msg);
        }

        public void PublishSourceIsNotBeingHandledMessage(LaceEventSource source)
        {
            var msg = new LaceSourceHandledEventMessage(_aggerateId, source,
                PublishableLaceMessages.ExternalSourceIsNotBeingHandled());
            PublishMessage(msg);
        }

        public void PublishTransformationStartMessage(LaceEventSource source)
        {
            var msg = new LaceTransformResponseEventMessage(_aggerateId, source,
                PublishableLaceMessages.TransformingResponseFromExternalSourceHasStarted());
            PublishMessage(msg);
        }

        public void PublishTransformationEndMessage(LaceEventSource source)
        {
            var msg = new LaceTransformResponseEventMessage(_aggerateId, source,
                PublishableLaceMessages.TransformingResponseFromExternalSourceHasFinished());
            PublishMessage(msg);
        }

        public void PublishTransformationFailedMessage(LaceEventSource source)
        {
            var msg = new LaceTransformResponseEventMessage(_aggerateId, source,
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
