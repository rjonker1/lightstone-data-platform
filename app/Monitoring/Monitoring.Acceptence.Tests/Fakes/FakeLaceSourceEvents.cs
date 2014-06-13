using System;
using Monitoring.Consumer.Lace.Consumers;
using Monitoring.Consumer.Lace.Messages;
using Monitoring.Sources.Lace;

namespace Monitoring.Acceptance.Tests.Fakes
{
    public class FakeLaceExternalSourceEvents
    {

        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> ReceiveRequestInLace = (aggrId, consumer) => LaceExternalSourceEvents.ReciveRequestIntoLace(aggrId, consumer);
        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> ReturnResponseFromLace = (aggrId, consumer) => LaceExternalSourceEvents.ReturnResponseFromLace(aggrId, consumer);


        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> StartCallingIvid = (aggrId, consumer) => LaceExternalSourceEvents.IvidSourceCallStarting(aggrId,consumer);
        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> EndCallingIvid = (aggrId, consumer) => LaceExternalSourceEvents.IvidSourceCallEnded(aggrId, consumer);

        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> StartCallingIvidTileHolder = (aggrId, consumer) => LaceExternalSourceEvents.IvidTitleHolderCallStarting(aggrId, consumer);
        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> EndCallingIvidTitleHolder = (aggrId, consumer) => LaceExternalSourceEvents.IvidTitleHolderSourceCallEnded(aggrId, consumer);

        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> StartCallingRgtVin = (aggrId, consumer) => LaceExternalSourceEvents.RgtVinSourceCallStarting(aggrId, consumer);
        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> EndCallingRgtVin = (aggrId, consumer) => LaceExternalSourceEvents.RgtVinSourceSourceCallEnded(aggrId, consumer);

        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> StartCallingAudatex = (aggrId, consumer) => LaceExternalSourceEvents.AudatexSourceCallStarting(aggrId, consumer);
        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> EndCallingAudatex = (aggrId, consumer) => LaceExternalSourceEvents.AudatexSourceSourceCallEnded(aggrId, consumer);


    }

    internal class LaceExternalSourceEvents
    {
        internal static ExternalSourceConsumer IvidSourceCallStarting(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.Ivid,
                PublishableLaceMessages.StartCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceConsumer();

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceConsumer IvidSourceCallEnded(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.Ivid,
                PublishableLaceMessages.EndCallingExternalSource());

            if(consumer == null)
                consumer = new ExternalSourceConsumer();
            
            consumer.Consume(message);

            return consumer;
        }


        internal static ExternalSourceConsumer IvidTitleHolderCallStarting(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.IvidTitleHolder,
                PublishableLaceMessages.StartCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceConsumer();

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceConsumer IvidTitleHolderSourceCallEnded(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.IvidTitleHolder,
                PublishableLaceMessages.EndCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceConsumer();

            consumer.Consume(message);

            return consumer;
        }


        internal static ExternalSourceConsumer RgtVinSourceCallStarting(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.RgtVin,
                PublishableLaceMessages.StartCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceConsumer();

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceConsumer RgtVinSourceSourceCallEnded(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.RgtVin,
                PublishableLaceMessages.EndCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceConsumer();

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceConsumer AudatexSourceCallStarting(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.Audatex,
                PublishableLaceMessages.StartCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceConsumer();

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceConsumer AudatexSourceSourceCallEnded(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.Audatex,
                PublishableLaceMessages.EndCallingExternalSource());

            if (consumer == null)
                consumer = new ExternalSourceConsumer();

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceConsumer ReturnResponseFromLace(Guid aggregateId, ExternalSourceConsumer consumer)
        {
            var message = new LaceExternalSourceEventMessage(aggregateId, LaceEventSource.Initialization,
               PublishableLaceMessages.LaceProcessedRequestAndResturnedResponse());

            if (consumer == null)
                consumer = new ExternalSourceConsumer();

            consumer.Consume(message);

            return consumer;
        }

        internal static ExternalSourceConsumer ReciveRequestIntoLace(Guid aggregateId, ExternalSourceConsumer consumer)
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
