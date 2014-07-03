using System;
using EventTracking.Tests.Helper.Mother.Monitoring;
using Monitoring.Consumer.Lace.Consumers;

namespace EventTracking.Tests.Helper.Fakes.Lace
{
    public class FakeExternalSourceEvents
    {
        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> ReceiveRequestInLace =
           (aggrId, consumer) => ExternalSourceEventConsumers.ReciveRequestIntoLace(aggrId, consumer);

        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> ReturnResponseFromLace =
            (aggrId, consumer) => ExternalSourceEventConsumers.ReturnResponseFromLace(aggrId, consumer);


        public static Func<Guid, ExternalSourceExecutedConsumer, ExternalSourceExecutedConsumer> StartCallingIvid =
            (aggrId, consumer) => ExternalSourceEventConsumers.IvidSourceCallStarting(aggrId, consumer);

        public static Func<Guid, ExternalSourceExecutedConsumer, ExternalSourceExecutedConsumer> EndCallingIvid =
            (aggrId, consumer) => ExternalSourceEventConsumers.IvidSourceCallEnded(aggrId, consumer);

        public static Func<Guid, ExternalSourceExecutedConsumer, ExternalSourceExecutedConsumer> StartCallingIvidTileHolder =
            (aggrId, consumer) => ExternalSourceEventConsumers.IvidTitleHolderCallStarting(aggrId, consumer);

        public static Func<Guid, ExternalSourceExecutedConsumer, ExternalSourceExecutedConsumer> EndCallingIvidTitleHolder =
            (aggrId, consumer) => ExternalSourceEventConsumers.IvidTitleHolderSourceCallEnded(aggrId, consumer);

        public static Func<Guid, ExternalSourceExecutedConsumer, ExternalSourceExecutedConsumer> StartCallingRgtVin =
            (aggrId, consumer) => ExternalSourceEventConsumers.RgtVinSourceCallStarting(aggrId, consumer);

        public static Func<Guid, ExternalSourceExecutedConsumer, ExternalSourceExecutedConsumer> EndCallingRgtVin =
            (aggrId, consumer) => ExternalSourceEventConsumers.RgtVinSourceSourceCallEnded(aggrId, consumer);

        public static Func<Guid, ExternalSourceExecutedConsumer, ExternalSourceExecutedConsumer> StartCallingAudatex =
            (aggrId, consumer) => ExternalSourceEventConsumers.AudatexSourceCallStarting(aggrId, consumer);

        public static Func<Guid, ExternalSourceExecutedConsumer, ExternalSourceExecutedConsumer> EndCallingAudatex =
            (aggrId, consumer) => ExternalSourceEventConsumers.AudatexSourceSourceCallEnded(aggrId, consumer);
    }
}
