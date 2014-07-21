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
            var msg = new LaceEventMessage(_aggerateId, source, message, 0);
            PublishMessage(msg);
        }


        public void PublishLaceReceivedRequestMessage(LaceEventSource source)
        {
            var message = new LaceExternalSourceEventMessage(_aggerateId, source,
                PublishableLaceMessages.LaceReceivedRequestStarted, 1);
            PublishMessage(message);
        }

        public void PublishLaceProcessedRequestAndReturnedResponseMessage(LaceEventSource source)
        {
            var message = new LaceExternalSourceEventMessage(_aggerateId, source,
                PublishableLaceMessages.LaceProcessedRequestAndResturnedResponse, 2);
            PublishMessage(message);
        }

        public void PublishLaceRequestWasNotProcessedAndErrorHasBeenLoggedMessage(LaceEventSource source)
        {
            var message = new LaceExternalSourceEventMessage(_aggerateId, source,
                PublishableLaceMessages.LaceCannotProcessRequestAndErrorHasBeenLogged, 0);
            PublishMessage(message);
        }


        public void PublishStartSourceCallMessage(LaceEventSource source)
        {
            var msg = new LaceExternalSourceExecutionEventMessage(_aggerateId, source,
                PublishableLaceMessages.StartCallingExternalSource, 1);
            PublishMessage(msg);
        }

        public void PublishStartSourceConfigurationMessage(LaceEventSource source)
        {
            var msg = new LaceExternalSourceConfigurationEventMessage(_aggerateId, source,
                PublishableLaceMessages.StartConfigurationForExternalSource, 1);
            PublishMessage(msg);
        }

        public void PublishEndSourceConfigurationMessage(LaceEventSource source)
        {
            var msg = new LaceExternalSourceConfigurationEventMessage(_aggerateId, source,
                PublishableLaceMessages.EndConfigurationForExternalSource, 2);
            PublishMessage(msg);
        }

        public void PublishEndSourceCallMessage(LaceEventSource source)
        {
            var msg = new LaceExternalSourceExecutionEventMessage(_aggerateId, source,
                PublishableLaceMessages.EndCallingExternalSource, 2);
            PublishMessage(msg);
        }

        public void PublishFailedSourceCallMessaage(LaceEventSource source)
        {
            var msg = new LaceExternalSourceFailedEventMessage(_aggerateId, source,
                PublishableLaceMessages.ExternalSourceCallFailed, 0);
            PublishMessage(msg);
        }

        public void PublishNoResponseFromSourceMessage(LaceEventSource source)
        {
            var msg = new LaceExternalSourceNoResponseEventMessage(_aggerateId, source,
                PublishableLaceMessages.NoResponseReceivedFromExternalSource, 0);
            PublishMessage(msg);
        }

        public void PublishSourceRequestMessage(LaceEventSource source, string request)
        {
            var msg = new LaceExternalSourceRequestEventMessage(_aggerateId, source,
                PublishableLaceMessages.RequestSentToExternalSource,
                request, 1);
            PublishMessage(msg);

        }

        public void PublishSourceResponseMessage(LaceEventSource source, string response)
        {
            var msg = new LaceExternalSourceResponseEventMessage(_aggerateId, source,
                PublishableLaceMessages.ResponseReceivedFromExternalSource, response, 2);
            PublishMessage(msg);
        }


        public void PublishSourceIsBeingHandledMessage(LaceEventSource source)
        {
            var msg = new LaceSourceHandledEventMessage(_aggerateId, source,
                PublishableLaceMessages.ExternalSourceIsBeingHandled, 0);
            PublishMessage(msg);
        }

        public void PublishSourceIsNotBeingHandledMessage(LaceEventSource source)
        {
            var msg = new LaceSourceHandledEventMessage(_aggerateId, source,
                PublishableLaceMessages.ExternalSourceIsNotBeingHandled, 0);
            PublishMessage(msg);
        }

        public void PublishTransformationStartMessage(LaceEventSource source)
        {
            var msg = new LaceTransformResponseEventMessage(_aggerateId, source,
                PublishableLaceMessages.TransformingResponseFromExternalSourceHasStarted, 1);
            PublishMessage(msg);
        }

        public void PublishTransformationEndMessage(LaceEventSource source)
        {
            var msg = new LaceTransformResponseEventMessage(_aggerateId, source,
                PublishableLaceMessages.TransformingResponseFromExternalSourceHasFinished, 2);
            PublishMessage(msg);
        }

        public void PublishTransformationFailedMessage(LaceEventSource source)
        {
            var msg = new LaceTransformResponseEventMessage(_aggerateId, source,
                PublishableLaceMessages.TransformingResponseFromExternalSourceHasFailed, 0);
            PublishMessage(msg);
        }


        private void PublishMessage<T>(T message) where T : class, IPublishableMessage
        {
            Task.Run(() => PublishMessageAsync(message));
        }

        private void PublishMessageAsync<T>(T message) where T : class, IPublishableMessage
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
    }
}
