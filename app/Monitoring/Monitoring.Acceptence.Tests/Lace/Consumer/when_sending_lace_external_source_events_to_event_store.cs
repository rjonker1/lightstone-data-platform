using System;
using System.Threading;
using Monitoring.Consumer.Lace.Consumers;
using Monitoring.Consumer.Lace.Messages;
using Monitoring.Sources.Lace;
using Xunit.Extensions;

namespace Monitoring.Acceptence.Tests.Lace.Consumer
{
    public class when_sending_lace_external_source_events_to_event_store : Specification
    {

        private readonly Guid _aggregateId;

        public when_sending_lace_external_source_events_to_event_store()
        {
            _aggregateId = Guid.NewGuid();
        }

        public override void Observe()
        {
            
        }

        [Observation]
        public void monitoring_lace_external_source_start_and_end_service_call_consumed_must_be_true()
        {
            var message = new LaceExternalSourceEventMessage(_aggregateId, ExternalSource.IvidSource,
                "Starting External Web Service Call");

            var consumer = new ExternalSourceConsumer();
            consumer.Consume(message);
            consumer.HasBeenConsumed.ShouldBeTrue();


            Thread.Sleep(5000);


            message = new LaceExternalSourceEventMessage(_aggregateId, ExternalSource.IvidSource,
               "End External Web Service Call");

            // consumer = new ExternalSourceConsumer();
            consumer.Consume(message);
            consumer.HasBeenConsumed.ShouldBeTrue();
        }
    }
}
