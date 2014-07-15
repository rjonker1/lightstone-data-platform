using System;
using EventTracking.Domain.Persistence;
using EventTracking.Domain.Persistence.EventStore;
using Monitoring.Consumer.Lace.Consumers;
using Monitoring.Consumer.Lace.Messages;
using Monitoring.Sources.Lace;

namespace Monitoring.Acceptance.Tests.Fakes
{
    public class FakeLaceExternalSourceEvents
    {

        public static Func<Guid, ExternalSourceConsumer, IPersistAnEvent, ExternalSourceConsumer> ReceiveRequestInLace =
            (aggrId, consumer, persist) => LaceExternalSourceEvents.ReciveRequestIntoLace(aggrId, consumer, persist);

        public static Func<Guid, ExternalSourceConsumer, IPersistAnEvent, ExternalSourceConsumer> ReturnResponseFromLace =
            (aggrId, consumer, persist) => LaceExternalSourceEvents.ReturnResponseFromLace(aggrId, consumer, persist);


        public static Func<Guid, ExternalSourceExecutedConsumer, IPersistAnEvent, ExternalSourceExecutedConsumer>
            StartCallingIvid =
                (aggrId, consumer, persist) =>
                    LaceExternalSourceEvents.IvidSourceCallStarting(aggrId, consumer, persist);

        public static Func<Guid, ExternalSourceExecutedConsumer, IPersistAnEvent, ExternalSourceExecutedConsumer>
            EndCallingIvid =
                (aggrId, consumer, persist) => LaceExternalSourceEvents.IvidSourceCallEnded(aggrId, consumer, persist);

        public static Func<Guid, ExternalSourceExecutedConsumer, IPersistAnEvent, ExternalSourceExecutedConsumer>
            StartCallingIvidTileHolder =
                (aggrId, consumer, persist) =>
                    LaceExternalSourceEvents.IvidTitleHolderCallStarting(aggrId, consumer, persist);

        public static Func<Guid, ExternalSourceExecutedConsumer, IPersistAnEvent, ExternalSourceExecutedConsumer>
            EndCallingIvidTitleHolder =
                (aggrId, consumer, persist) =>
                    LaceExternalSourceEvents.IvidTitleHolderSourceCallEnded(aggrId, consumer, persist);

        public static Func<Guid, ExternalSourceExecutedConsumer, IPersistAnEvent, ExternalSourceExecutedConsumer>
            StartCallingRgtVin =
                (aggrId, consumer, persist) =>
                    LaceExternalSourceEvents.RgtVinSourceCallStarting(aggrId, consumer, persist);

        public static Func<Guid, ExternalSourceExecutedConsumer, IPersistAnEvent, ExternalSourceExecutedConsumer>
            EndCallingRgtVin =
                (aggrId, consumer, persist) =>
                    LaceExternalSourceEvents.RgtVinSourceSourceCallEnded(aggrId, consumer, persist);

        public static Func<Guid, ExternalSourceExecutedConsumer, IPersistAnEvent, ExternalSourceExecutedConsumer>
            StartCallingAudatex =
                (aggrId, consumer, persist) =>
                    LaceExternalSourceEvents.AudatexSourceCallStarting(aggrId, consumer, persist);

        public static Func<Guid, ExternalSourceExecutedConsumer, IPersistAnEvent, ExternalSourceExecutedConsumer>
            EndCallingAudatex =
                (aggrId, consumer, persist) =>
                    LaceExternalSourceEvents.AudatexSourceSourceCallEnded(aggrId, consumer, persist);

    }

    internal class LaceExternalSourceEvents
    {

        internal static ExternalSourceExecutedConsumer IvidSourceCallStarting(Guid aggregateId,
            ExternalSourceExecutedConsumer consumer, IPersistAnEvent persistEvent)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.Ivid,
                PublishableLaceMessages.StartCallingExternalSource, 1);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(persistEvent);

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceExecutedConsumer IvidSourceCallEnded(Guid aggregateId,
            ExternalSourceExecutedConsumer consumer, IPersistAnEvent persistEvent)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.Ivid,
                PublishableLaceMessages.EndCallingExternalSource, 2);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(persistEvent);

            consumer.Consume(message);

            return consumer;
        }


        internal static ExternalSourceExecutedConsumer IvidTitleHolderCallStarting(Guid aggregateId,
            ExternalSourceExecutedConsumer consumer, IPersistAnEvent persistEvent)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.IvidTitleHolder,
                PublishableLaceMessages.StartCallingExternalSource, 1);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(persistEvent);

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceExecutedConsumer IvidTitleHolderSourceCallEnded(Guid aggregateId,
            ExternalSourceExecutedConsumer consumer, IPersistAnEvent persistEvent)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.IvidTitleHolder,
                PublishableLaceMessages.EndCallingExternalSource, 2);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(persistEvent);

            consumer.Consume(message);

            return consumer;
        }


        internal static ExternalSourceExecutedConsumer RgtVinSourceCallStarting(Guid aggregateId,
            ExternalSourceExecutedConsumer consumer, IPersistAnEvent persistEvent)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.RgtVin,
                PublishableLaceMessages.StartCallingExternalSource, 1);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(persistEvent);

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceExecutedConsumer RgtVinSourceSourceCallEnded(Guid aggregateId,
            ExternalSourceExecutedConsumer consumer, IPersistAnEvent persistEvent)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.RgtVin,
                PublishableLaceMessages.EndCallingExternalSource, 2);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(persistEvent);

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceExecutedConsumer AudatexSourceCallStarting(Guid aggregateId,
            ExternalSourceExecutedConsumer consumer, IPersistAnEvent persistEvent)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.Audatex,
                PublishableLaceMessages.StartCallingExternalSource, 1);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(persistEvent);

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceExecutedConsumer AudatexSourceSourceCallEnded(Guid aggregateId,
            ExternalSourceExecutedConsumer consumer, IPersistAnEvent persistEvent)
        {
            var message = new LaceExternalSourceExecutionEventMessage(aggregateId, LaceEventSource.Audatex,
                PublishableLaceMessages.EndCallingExternalSource, 2);

            if (consumer == null)
                consumer = new ExternalSourceExecutedConsumer(persistEvent);

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceConsumer ReturnResponseFromLace(Guid aggregateId, ExternalSourceConsumer consumer,
            IPersistAnEvent persistEvent)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.Initialization,
                PublishableLaceMessages.LaceProcessedRequestAndResturnedResponse, 0);

            if (consumer == null)
                consumer = new ExternalSourceConsumer(persistEvent);

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceConsumer ReciveRequestIntoLace(Guid aggregateId, ExternalSourceConsumer consumer,
            IPersistAnEvent persistEvent)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.EntryPoint,
                PublishableLaceMessages.LaceReceivedRequestStarted, 1);

            if (consumer == null)
                consumer = new ExternalSourceConsumer(persistEvent);

            consumer.Consume(message);

            return consumer;
        }
    }
}
