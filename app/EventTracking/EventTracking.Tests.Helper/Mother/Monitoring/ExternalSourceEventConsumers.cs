using System;
using Monitoring.Consumer.Lace.Consumers;
using Monitoring.Consumer.Lace.Messages;
using Monitoring.Sources.Lace;

namespace EventTracking.Tests.Helper.Mother.Monitoring
{
    public class ExternalSourceEventConsumers
    {
        public static ExternalSourceConsumer IvidSourceCallStarting(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.Ivid,
                PublishableLaceMessages.StartCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceConsumer();

            consumer.Consume(message);

            return consumer;
        }

        public static ExternalSourceConsumer IvidSourceCallEnded(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.Ivid,
                PublishableLaceMessages.EndCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceConsumer();

            consumer.Consume(message);

            return consumer;
        }


        public static ExternalSourceConsumer IvidTitleHolderCallStarting(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.IvidTitleHolder,
                PublishableLaceMessages.StartCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceConsumer();

            consumer.Consume(message);

            return consumer;
        }

        public static ExternalSourceConsumer IvidTitleHolderSourceCallEnded(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.IvidTitleHolder,
                PublishableLaceMessages.EndCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceConsumer();

            consumer.Consume(message);

            return consumer;
        }


        public static ExternalSourceConsumer RgtVinSourceCallStarting(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.RgtVin,
                PublishableLaceMessages.StartCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceConsumer();

            consumer.Consume(message);

            return consumer;
        }

        public static ExternalSourceConsumer RgtVinSourceSourceCallEnded(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.RgtVin,
                PublishableLaceMessages.EndCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceConsumer();

            consumer.Consume(message);

            return consumer;
        }

        public static ExternalSourceConsumer AudatexSourceCallStarting(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.Audatex,
                PublishableLaceMessages.StartCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceConsumer();

            consumer.Consume(message);

            return consumer;
        }

        public static ExternalSourceConsumer AudatexSourceSourceCallEnded(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.Audatex,
                PublishableLaceMessages.EndCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceConsumer();

            consumer.Consume(message);

            return consumer;
        }

        public static ExternalSourceConsumer ReturnResponseFromLace(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.Initialization,
               PublishableLaceMessages.LaceProcessedRequestAndResturnedResponse());

            if (consumer == null)
                consumer = new ExternalSourceConsumer();

            consumer.Consume(message);

            return consumer;
        }

        public static ExternalSourceConsumer ReciveRequestIntoLace(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.EntryPoint,
               PublishableLaceMessages.LaceReceivedRequestStarted());

            if (consumer == null)
                consumer = new ExternalSourceConsumer();

            consumer.Consume(message);

            return consumer;
        }
    }
}
