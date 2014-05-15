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

        public void PublishMessage(ILaceEventMessage message)
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

        public void PublishMessage(Guid aggerateId, string message, EventSource source)
        {
            var msg = new LaceEventMessage() {AggregateId = aggerateId, Message = message, Source = source};
            PublishMessage(msg);
        }

        public void PublishStartServiceCallMessage(Guid aggerateId, EventSource source)
        {
            var msg = new LaceExternalServiceEventMessage()
            {
                AggregateId = aggerateId,
                Message = "Starting External Web Service Call",
                Source = source
            };
            PublishMessage(msg);
        }

        public void PublishStartServiceConfigurationMessage(Guid aggerateId, EventSource source)
        {
            var msg = new LaceExternalServiceConfigurationEventMessage()
            {
                AggregateId = aggerateId,
                Message = "Starting Configuration for Web Service Call",
                Source = source
            };
            PublishMessage(msg);
        }

        public void PublishEndServiceConfigurationMessage(Guid aggerateId, EventSource source)
        {
            var msg = new LaceExternalServiceConfigurationEventMessage()
            {
                AggregateId = aggerateId,
                Message = "Starting Configuration for Web Service Call",
                Source = source
            };
            PublishMessage(msg);
        }

        public void PublishEndServiceCallMessage(Guid aggerateId, EventSource source)
        {
            var msg = new LaceExternalServiceEventMessage()
            {
                AggregateId = aggerateId,
                Message = "End External Web Service Call",
                Source = source
            };
            PublishMessage(msg);
        }

        public void PublishFailedServiceCallMessaage(Guid aggerateId, EventSource source)
        {
            var msg = new LaceExternalServiceFailedEventMessage()
            {
                AggregateId = aggerateId,
                Message = "Failed External Web Service Call",
                Source = source
            };
            PublishMessage(msg);
        }

        public void PublishNoResponseFromServiceMessage(Guid aggerateId, EventSource source)
        {
            var msg = new LaceExternalServiceNoResponseEventMessage()
            {
                AggregateId = aggerateId,
                Message = "Response from Web Service is null or does not exist",
                Source = source
            };
            PublishMessage(msg);
        }

        public void PublishServiceRequestMessage(Guid aggerateId, EventSource source, string request)
        {
            var msg = new LaceExternalServiceRequestEventMessage()
            {
                AggregateId = aggerateId,
                Message = string.Format("Response Received from Web Service: {0}", request),
                Source = source
            };
            PublishMessage(msg);
        }

        public void PublishServiceResponseMessage(Guid aggerateId, EventSource source, string response)
        {
            var msg = new LaceEventMessage()
            {
                AggregateId = aggerateId,
                Message = string.Format("Request Sent to Web Service: {0}", response),
                Source = source
            };
            PublishMessage(msg);
        }

       

    }
}
