using System;
using Monitoring.Consumer.Lace.Consumers;
using Monitoring.Consumer.Lace.Messages;
using Monitoring.Sources.Lace;

namespace EventTracking.Tests.Helper.Mother.Monitoring
{
    public class ExternalSourceEventConsumers
    {
        public static ExternalSourceExecutedConsumer IvidSourceCallStarting(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.Ivid,
                PublishableLaceMessages.StartCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer();

            consumer.Consume(message);

            return consumer;
        }

        public static ExternalSourceExecutedConsumer IvidSourceCallEnded(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.Ivid,
                PublishableLaceMessages.EndCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer();

            consumer.Consume(message);

            return consumer;
        }


        public static ExternalSourceExecutedConsumer IvidTitleHolderCallStarting(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.IvidTitleHolder,
                PublishableLaceMessages.StartCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer();

            consumer.Consume(message);

            return consumer;
        }

        public static ExternalSourceExecutedConsumer IvidTitleHolderSourceCallEnded(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.IvidTitleHolder,
                PublishableLaceMessages.EndCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer();

            consumer.Consume(message);

            return consumer;
        }


        public static ExternalSourceExecutedConsumer RgtVinSourceCallStarting(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.RgtVin,
                PublishableLaceMessages.StartCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer();

            consumer.Consume(message);

            return consumer;
        }

        public static ExternalSourceExecutedConsumer RgtVinSourceSourceCallEnded(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.RgtVin,
                PublishableLaceMessages.EndCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer();

            consumer.Consume(message);

            return consumer;
        }

        public static ExternalSourceExecutedConsumer AudatexSourceCallStarting(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.Audatex,
                PublishableLaceMessages.StartCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer();

            consumer.Consume(message);

            return consumer;
        }

        public static ExternalSourceExecutedConsumer AudatexSourceSourceCallEnded(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.Audatex,
                PublishableLaceMessages.EndCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer();

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
