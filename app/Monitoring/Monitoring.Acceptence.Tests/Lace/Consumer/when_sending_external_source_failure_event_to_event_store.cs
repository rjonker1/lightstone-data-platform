using System;
using Monitoring.Consumer.Lace.Consumers;
using Monitoring.Consumer.Lace.Messages;
using Monitoring.Sources.Lace;
using Xunit.Extensions;

namespace Monitoring.Acceptance.Tests.Lace.Consumer
{
    public class when_sending_external_source_failure_event_to_event_store : Specification
    {
        private readonly Guid _aggregateId;
        private ExternalSourceFailedConsumer _consumer;
        private LaceExternalSourceFailedEventMessage _message;

        public when_sending_external_source_failure_event_to_event_store()
        {
            _aggregateId = Guid.NewGuid();
        }

        public override void Observe()
        {
            _message = new LaceExternalSourceFailedEventMessage(_aggregateId, LaceEventSource.Ivid,
                PublishableLaceMessages.ExternalSourceCallFailed());

            if (_consumer == null)
                _consumer = new ExternalSourceFailedConsumer();

            _consumer.Consume(_message);
        }

        [Observation]
        public void monitoring_lace_external_source_failure_event_source_must_be_consumed_true()
        {
            _consumer.HasBeenConsumed.ShouldBeTrue();
        }
}
}
