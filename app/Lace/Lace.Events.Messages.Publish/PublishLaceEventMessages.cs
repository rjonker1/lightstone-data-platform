using System;
using Common.Logging;
using System.Threading.Tasks;
using DataPlatform.Shared.Public.Messaging;
using Monitoring.Consumer.Lace.Messages;
using Monitoring.Sources;
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

        public void PublishMessage(Guid aggerateId, string message, FromSource source)
        {
            var msg = new LaceEventMessage(aggerateId, source, message);
            PublishMessage(msg);
        }

        public void PublishStartServiceCallMessage(Guid aggerateId, FromSource source)
        {
            var msg = new LaceExternalSourceEventMessage(aggerateId, source, "Starting External Web Service Call");
            PublishMessage(msg);
        }

        public void PublishStartServiceConfigurationMessage(Guid aggerateId, FromSource source)
        {
            var msg = new LaceExternalSourceConfigurationEventMessage(aggerateId, source,
                "Starting Configuration for Web Service Call");
            PublishMessage(msg);
        }

        public void PublishEndServiceConfigurationMessage(Guid aggerateId, FromSource source)
        {
            var msg = new LaceExternalSourceConfigurationEventMessage(aggerateId, source,
                "Ending Configuration for Web Service Call");
            PublishMessage(msg);
        }

        public void PublishEndServiceCallMessage(Guid aggerateId, FromSource source)
        {
            var msg = new LaceExternalSourceEventMessage(aggerateId, source, "End External Web Service Call");
            PublishMessage(msg);
        }

        public void PublishFailedServiceCallMessaage(Guid aggerateId, FromSource source)
        {
            var msg = new LaceExternalSourceFailedEventMessage(aggerateId, source, "Failed External Web Service Call");
            PublishMessage(msg);
        }

        public void PublishNoResponseFromServiceMessage(Guid aggerateId, FromSource source)
        {
            var msg = new LaceExternalSourceNoResponseEventMessage(aggerateId, source,
                "Response from Web Service is null or does not exist");
            PublishMessage(msg);
        }

        public void PublishServiceRequestMessage(Guid aggerateId, FromSource source, string request)
        {
            var msg = new LaceExternalSourceRequestEventMessage(aggerateId, source, "Request Sent to Web Service",
                request);
            PublishMessage(msg);

        }

        public void PublishServiceResponseMessage(Guid aggerateId, FromSource source, string response)
        {
            var msg = new LaceExternalSourceResponseEventMessage(aggerateId, source,
                "Response Received from Web Service", response);
            PublishMessage(msg);
        }


        public void PublishSourceIsBeingHandledMessage(Guid aggerateId, FromSource source)
        {
            var msg = new LaceSourceHandledEventMessage(aggerateId, source, "Source is being handled");
            PublishMessage(msg);
        }

        public void PublishSourceIsNotBeingHandledMessage(Guid aggerateId, FromSource source)
        {
            var msg = new LaceSourceHandledEventMessage(aggerateId, source, "Source is NOT being handled");
            PublishMessage(msg);
        }

        public void PublishTransformationStartMessage(Guid aggerateId, FromSource source)
        {
            var msg = new LaceTransformResponseEventMessage(aggerateId, source,
                "Start Transforming Response from Source");
            PublishMessage(msg);
        }

        public void PublishTransformationEndMessage(Guid aggerateId, FromSource source)
        {
            var msg = new LaceTransformResponseEventMessage(aggerateId, source, "End Transforming Response from Source");
            PublishMessage(msg);
        }

        public void PublishTransformationFailedMessage(Guid aggerateId, FromSource source)
        {
            var msg = new LaceTransformResponseEventMessage(aggerateId, source,
                "Transforming Response from Source Failed");
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
