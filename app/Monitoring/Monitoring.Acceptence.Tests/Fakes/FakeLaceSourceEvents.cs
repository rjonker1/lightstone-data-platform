using System;
using EventTracking.Domain.Persistence.EventStore;
using Monitoring.Consumer.Lace.Consumers;
using Monitoring.Consumer.Lace.Messages;
using Monitoring.Sources.Lace;

namespace Monitoring.Acceptance.Tests.Fakes
{
    public class FakeLaceExternalSourceEvents
    {

        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> ReceiveRequestInLace =
            (aggrId, consumer) => LaceExternalSourceEvents.ReciveRequestIntoLace(aggrId, consumer);

        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> ReturnResponseFromLace =
            (aggrId, consumer) => LaceExternalSourceEvents.ReturnResponseFromLace(aggrId, consumer);


        public static Func<Guid, ExternalSourceExecutedConsumer, ExternalSourceExecutedConsumer> StartCallingIvid =
            (aggrId, consumer) => LaceExternalSourceEvents.IvidSourceCallStarting(aggrId, consumer);

        public static Func<Guid, ExternalSourceExecutedConsumer, ExternalSourceExecutedConsumer> EndCallingIvid =
            (aggrId, consumer) => LaceExternalSourceEvents.IvidSourceCallEnded(aggrId, consumer);

        public static Func<Guid, ExternalSourceExecutedConsumer, ExternalSourceExecutedConsumer>
            StartCallingIvidTileHolder =
                (aggrId, consumer) => LaceExternalSourceEvents.IvidTitleHolderCallStarting(aggrId, consumer);

        public static Func<Guid, ExternalSourceExecutedConsumer, ExternalSourceExecutedConsumer>
            EndCallingIvidTitleHolder =
                (aggrId, consumer) => LaceExternalSourceEvents.IvidTitleHolderSourceCallEnded(aggrId, consumer);

        public static Func<Guid, ExternalSourceExecutedConsumer, ExternalSourceExecutedConsumer> StartCallingRgtVin =
            (aggrId, consumer) => LaceExternalSourceEvents.RgtVinSourceCallStarting(aggrId, consumer);

        public static Func<Guid, ExternalSourceExecutedConsumer, ExternalSourceExecutedConsumer> EndCallingRgtVin =
            (aggrId, consumer) => LaceExternalSourceEvents.RgtVinSourceSourceCallEnded(aggrId, consumer);

        public static Func<Guid, ExternalSourceExecutedConsumer, ExternalSourceExecutedConsumer> StartCallingAudatex =
            (aggrId, consumer) => LaceExternalSourceEvents.AudatexSourceCallStarting(aggrId, consumer);

        public static Func<Guid, ExternalSourceExecutedConsumer, ExternalSourceExecutedConsumer> EndCallingAudatex =
            (aggrId, consumer) => LaceExternalSourceEvents.AudatexSourceSourceCallEnded(aggrId, consumer);

    }

    internal class LaceExternalSourceEvents
    {

        internal static ExternalSourceExecutedConsumer IvidSourceCallStarting(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.Ivid,
                PublishableLaceMessages.StartCallingExternalSource,1);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(new PersistEvent());

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceExecutedConsumer IvidSourceCallEnded(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.Ivid,
                PublishableLaceMessages.EndCallingExternalSource,2);

            if(consumer == null)
                consumer = new ExternalSourceExecutedConsumer(new PersistEvent());
            
            consumer.Consume(message);

            return consumer;
        }


        internal static ExternalSourceExecutedConsumer IvidTitleHolderCallStarting(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.IvidTitleHolder,
                PublishableLaceMessages.StartCallingExternalSource,1);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(new PersistEvent());

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceExecutedConsumer IvidTitleHolderSourceCallEnded(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.IvidTitleHolder,
                PublishableLaceMessages.EndCallingExternalSource,2);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(new PersistEvent());

            consumer.Consume(message);

            return consumer;
        }


        internal static ExternalSourceExecutedConsumer RgtVinSourceCallStarting(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.RgtVin,
                PublishableLaceMessages.StartCallingExternalSource,1);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(new PersistEvent());

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceExecutedConsumer RgtVinSourceSourceCallEnded(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.RgtVin,
                PublishableLaceMessages.EndCallingExternalSource,2);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(new PersistEvent());

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceExecutedConsumer AudatexSourceCallStarting(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.Audatex,
                PublishableLaceMessages.StartCallingExternalSource,1);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(new PersistEvent());

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceExecutedConsumer AudatexSourceSourceCallEnded(Guid aggregateId, ExternalSourceExecutedConsumer consumer)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.Audatex,
                PublishableLaceMessages.EndCallingExternalSource,2);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(new PersistEvent());

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceConsumer ReturnResponseFromLace(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.Initialization,
               PublishableLaceMessages.LaceProcessedRequestAndResturnedResponse,0);

            if (consumer == null)
                consumer = new ExternalSourceConsumer(new PersistEvent());

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceConsumer ReciveRequestIntoLace(Guid aggregateId, ExternalSourceConsumer consumer)
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
