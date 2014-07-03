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


        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> StartCallingIvid =
            (aggrId, consumer) => ExternalSourceEventConsumers.IvidSourceCallStarting(aggrId, consumer);

        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> EndCallingIvid =
            (aggrId, consumer) => ExternalSourceEventConsumers.IvidSourceCallEnded(aggrId, consumer);

        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> StartCallingIvidTileHolder =
            (aggrId, consumer) => ExternalSourceEventConsumers.IvidTitleHolderCallStarting(aggrId, consumer);

        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> EndCallingIvidTitleHolder =
            (aggrId, consumer) => ExternalSourceEventConsumers.IvidTitleHolderSourceCallEnded(aggrId, consumer);

        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> StartCallingRgtVin =
            (aggrId, consumer) => ExternalSourceEventConsumers.RgtVinSourceCallStarting(aggrId, consumer);

        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> EndCallingRgtVin =
            (aggrId, consumer) => ExternalSourceEventConsumers.RgtVinSourceSourceCallEnded(aggrId, consumer);

        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> StartCallingAudatex =
            (aggrId, consumer) => ExternalSourceEventConsumers.AudatexSourceCallStarting(aggrId, consumer);

        public static Func<Guid, ExternalSourceConsumer, ExternalSourceConsumer> EndCallingAudatex =
            (aggrId, consumer) => ExternalSourceEventConsumers.AudatexSourceSourceCallEnded(aggrId, consumer);
    }
}
