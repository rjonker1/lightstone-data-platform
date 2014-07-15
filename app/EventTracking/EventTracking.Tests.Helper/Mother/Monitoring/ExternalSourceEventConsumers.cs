using System;
using EventTracking.Domain.Persistence.EventStore;
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
                PublishableLaceMessages.StartCallingExternalSource,1);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(new PersistEvent());

            consumer.Consume(message);

            return consumer;
        }

        public static ExternalSourceExecutedConsumer IvidSourceCallEnded(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.Ivid,
                PublishableLaceMessages.EndCallingExternalSource,2);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(new PersistEvent());

            consumer.Consume(message);

            return consumer;
        }


        public static ExternalSourceExecutedConsumer IvidTitleHolderCallStarting(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.IvidTitleHolder,
                PublishableLaceMessages.StartCallingExternalSource,1);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(new PersistEvent());

            consumer.Consume(message);

            return consumer;
        }

        public static ExternalSourceExecutedConsumer IvidTitleHolderSourceCallEnded(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.IvidTitleHolder,
                PublishableLaceMessages.EndCallingExternalSource,2);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(new PersistEvent());

            consumer.Consume(message);

            return consumer;
        }


        public static ExternalSourceExecutedConsumer RgtVinSourceCallStarting(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.RgtVin,
                PublishableLaceMessages.StartCallingExternalSource,1);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(new PersistEvent());

            consumer.Consume(message);

            return consumer;
        }

        public static ExternalSourceExecutedConsumer RgtVinSourceSourceCallEnded(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.RgtVin,
                PublishableLaceMessages.EndCallingExternalSource,2);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(new PersistEvent());

            consumer.Consume(message);

            return consumer;
        }

        public static ExternalSourceExecutedConsumer AudatexSourceCallStarting(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.Audatex,
                PublishableLaceMessages.StartCallingExternalSource,1);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(new PersistEvent());

            consumer.Consume(message);

            return consumer;
        }

        public static ExternalSourceExecutedConsumer AudatexSourceSourceCallEnded(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.Audatex,
                PublishableLaceMessages.EndCallingExternalSource,2);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(new PersistEvent());

            consumer.Consume(message);

            return consumer;
        }

        public static ExternalSourceConsumer ReturnResponseFromLace(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.Initialization,
               PublishableLaceMessages.LaceProcessedRequestAndResturnedResponse,0);

            if (consumer == null)
                consumer = new ExternalSourceConsumer(new PersistEvent());

            consumer.Consume(message);

            return consumer;
        }

        public static ExternalSourceConsumer ReciveRequestIntoLace(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.EntryPoint,
               PublishableLaceMessages.LaceReceivedRequestStarted,1);

            if (consumer == null)
                consumer = new ExternalSourceConsumer(new PersistEvent());

            consumer.Consume(message);

            return consumer;
        }
    }
}
