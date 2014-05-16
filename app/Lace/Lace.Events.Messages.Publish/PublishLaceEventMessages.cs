using System;
using Common.Logging;
using System.Threading.Tasks;
using Lace.Shared.Enums;
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

        public void PublishMessage(Guid aggerateId, string message, EventSource source)
        {
            var msg = new LaceEventMessage(aggerateId, source, message);
            PublishMessage(msg);
        }

        public void PublishStartServiceCallMessage(Guid aggerateId, EventSource source)
        {
            var msg = new LaceExternalServiceEventMessage(aggerateId, source, "Starting External Web Service Call");
            PublishMessage(msg);
        }

        public void PublishStartServiceConfigurationMessage(Guid aggerateId, EventSource source)
        {
            var msg = new LaceExternalServiceConfigurationEventMessage(aggerateId, source,
                "Starting Configuration for Web Service Call");
            PublishMessage(msg);
        }

        public void PublishEndServiceConfigurationMessage(Guid aggerateId, EventSource source)
        {
            var msg = new LaceExternalServiceConfigurationEventMessage(aggerateId, source,
                "Ending Configuration for Web Service Call");
            PublishMessage(msg);
        }

        public void PublishEndServiceCallMessage(Guid aggerateId, EventSource source)
        {
            var msg = new LaceExternalServiceEventMessage(aggerateId, source, "End External Web Service Call");
            PublishMessage(msg);
        }

        public void PublishFailedServiceCallMessaage(Guid aggerateId, EventSource source)
        {
            var msg = new LaceExternalServiceFailedEventMessage(aggerateId, source, "Failed External Web Service Call");
            PublishMessage(msg);
        }

        public void PublishNoResponseFromServiceMessage(Guid aggerateId, EventSource source)
        {
            var msg = new LaceExternalServiceNoResponseEventMessage(aggerateId, source,
                "Response from Web Service is null or does not exist");
            PublishMessage(msg);
        }

        public void PublishServiceRequestMessage(Guid aggerateId, EventSource source, string request)
        {
            var msg = new LaceExternalServiceRequestEventMessage(aggerateId, source,
                string.Format("Response Received from Web Service: {0}", request));
            PublishMessage(msg);
        }

        public void PublishServiceResponseMessage(Guid aggerateId, EventSource source, string response)
        {
            var msg = new LaceEventMessage(aggerateId, source,
                string.Format("Request Sent to Web Service: {0}", response));
            PublishMessage(msg);
        }


        public void PublishSourceIsBeingHandledMessage(Guid aggerateId, EventSource source)
        {
            var msg = new LaceSourceHandledEventMessage(aggerateId, source, "Source is being handled");
            PublishMessage(msg);
        }

        public void PublishSourceIsNotBeingHandledMessage(Guid aggerateId, EventSource source)
        {
            var msg = new LaceSourceNotHandledEventMessage(aggerateId, source, "Source is being not handled");
            PublishMessage(msg);
        }

        public void PublishTransformationStartMessage(Guid aggerateId, EventSource source)
        {
            var msg = new LaceTransformResponseMessageEvent(aggerateId, source,
                "Start Transforming Response from Source");
            PublishMessage(msg);
        }

        public void PublishTransformationEndMessage(Guid aggerateId, EventSource source)
        {
            var msg = new LaceTransformResponseMessageEvent(aggerateId, source, "End Transforming Response from Source");
            PublishMessage(msg);
        }

        public void PublishTransformationFailedMessage(Guid aggerateId, EventSource source)
        {
            var msg = new LaceTransformResponseMessageEvent(aggerateId, source,
                "Transforming Response from Source Failed");
            PublishMessage(msg);
        }


        public void PublishMessage(ILaceEventMessage message)
        {

            //try
            //{
            //    _publishMessages.Publish(message);
            //}
            //catch (Exception ex)
            //{
            //    Log.ErrorFormat("Error Publishing message to Lace Event Queue: {0}", ex.Message);
            //}

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
