using System;
using EventTracking.Domain.Persistence;
using EventTracking.Tests.Helper.Mother.Monitoring;
using Monitoring.Consumer.Lace.Consumers;

namespace EventTracking.Tests.Helper.Fakes.Lace
{
    public class FakeExternalSourceEvents
    {

        public static Func<Guid, ExternalSourceConsumer, IPersistAnEvent, ExternalSourceConsumer> ReceiveRequestInLace =
            (aggrId, consumer, persistAnEvent) => ExternalSourceEventConsumers.ReciveRequestIntoLace(aggrId, consumer, persistAnEvent);

        public static Func<Guid, ExternalSourceConsumer, IPersistAnEvent, ExternalSourceConsumer> ReturnResponseFromLace =
            (aggrId, consumer, persistAnEvent) => ExternalSourceEventConsumers.ReturnResponseFromLace(aggrId, consumer, persistAnEvent);


        public static Func<Guid, ExternalSourceExecutedConsumer, IPersistAnEvent, ExternalSourceExecutedConsumer> StartCallingIvid =
            (aggrId, consumer, persistAnEvent) => ExternalSourceEventConsumers.IvidSourceCallStarting(aggrId, consumer, persistAnEvent);

        public static Func<Guid, ExternalSourceExecutedConsumer, IPersistAnEvent, ExternalSourceExecutedConsumer> EndCallingIvid =
            (aggrId, consumer, persistAnEvent) => ExternalSourceEventConsumers.IvidSourceCallEnded(aggrId, consumer, persistAnEvent);

        public static Func<Guid, ExternalSourceExecutedConsumer, IPersistAnEvent, ExternalSourceExecutedConsumer>
            StartCallingIvidTileHolder =
                (aggrId, consumer, persistAnEvent) =>
                    ExternalSourceEventConsumers.IvidTitleHolderCallStarting(aggrId, consumer, persistAnEvent);

        public static Func<Guid, ExternalSourceExecutedConsumer, IPersistAnEvent, ExternalSourceExecutedConsumer>
            EndCallingIvidTitleHolder =
                (aggrId, consumer, persistAnEvent) =>
                    ExternalSourceEventConsumers.IvidTitleHolderSourceCallEnded(aggrId, consumer, persistAnEvent);

        public static Func<Guid, ExternalSourceExecutedConsumer, IPersistAnEvent, ExternalSourceExecutedConsumer> StartCallingRgtVin =
            (aggrId, consumer, persistAnEvent) =>
                ExternalSourceEventConsumers.RgtVinSourceCallStarting(aggrId, consumer, persistAnEvent);

        public static Func<Guid, ExternalSourceExecutedConsumer, IPersistAnEvent, ExternalSourceExecutedConsumer> EndCallingRgtVin =
            (aggrId, consumer, persistAnEvent) =>
                ExternalSourceEventConsumers.RgtVinSourceSourceCallEnded(aggrId, consumer, persistAnEvent);

        public static Func<Guid, ExternalSourceExecutedConsumer, IPersistAnEvent, ExternalSourceExecutedConsumer> StartCallingAudatex =
            (aggrId, consumer, persistAnEvent) =>
                ExternalSourceEventConsumers.AudatexSourceCallStarting(aggrId, consumer, persistAnEvent);

        public static Func<Guid, ExternalSourceExecutedConsumer, IPersistAnEvent, ExternalSourceExecutedConsumer> EndCallingAudatex =
            (aggrId, consumer, persistAnEvent) =>
                ExternalSourceEventConsumers.AudatexSourceSourceCallEnded(aggrId, consumer, persistAnEvent);
    }
}
