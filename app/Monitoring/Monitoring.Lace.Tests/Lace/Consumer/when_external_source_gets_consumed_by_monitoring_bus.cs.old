using System;
using EventTracking.Domain.Persistence;
using Monitoring.Consumer.Lace.Consumers;
using Monitoring.Consumer.Lace.Messages;
using Monitoring.Sources.Lace;
using Monitoring.Test.Helper.Fakes;
using Monitoring.Test.Helper.Fakes.EventStore;
using Xunit.Extensions;


namespace Monitoring.Unit.Tests.Lace.Consumer
{
    public class when_external_source_gets_consumed_by_monitoring_bus : Specification
    {
        private readonly IPersistAnEvent _persistEvent;

        public when_external_source_gets_consumed_by_monitoring_bus()
        {
            _persistEvent = new FakePersistEvent();
        }


        public override void Observe()
        {
            FakeDatabase.Events.Clear();
        }


        [Observation]
        public void monitoring_lace_external_source_conumer_consumed_must_be_true()
        {
            var message = new LaceExternalSourceExecutionEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
                PublishableLaceMessages.StartCallingExternalSource, 1);

            var consumer = new ExternalSourceExecutedConsumer(_persistEvent);
            consumer.Consume(message);
            consumer.HasBeenConsumed.ShouldBeTrue();


            message = new LaceExternalSourceExecutionEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
               PublishableLaceMessages.EndCallingExternalSource, 2);

            // consumer = new ExternalSourceConsumer();
            consumer.Consume(message);
            consumer.HasBeenConsumed.ShouldBeTrue();
        }


        [Observation]
        public void monitoring_lace_external_source_configuration_consumer_consumed_must_be_true()
        {
            var message = new LaceExternalSourceConfigurationEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
                PublishableLaceMessages.StartConfigurationForExternalSource, 1);

            var consumer = new ExternalSourceConfigurationConsumer(_persistEvent);
            consumer.Consume(message);
            consumer.HasBeenConsumed.ShouldBeTrue();
        }

        [Observation]
        public void monitoring_lace_external_source_failed_consumer_consumed_must_be_true()
        {
            var message = new LaceExternalSourceFailedEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
               PublishableLaceMessages.ExternalSourceCallFailed, 0);

            var consumer = new ExternalSourceFailedConsumer(_persistEvent);
            consumer.Consume(message);
            consumer.HasBeenConsumed.ShouldBeTrue();
        }

        [Observation]
        public void monitoring_lace_external_source_handled_consumer_consumed_must_be_truee()
        {
            var message = new LaceSourceHandledEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
                PublishableLaceMessages.ExternalSourceIsBeingHandled, 0);

            var consumer = new ExternalSourceHandledConsumer(_persistEvent);
            consumer.Consume(message);
            consumer.HasBeenConsumed.ShouldBeTrue();
        }

        [Observation]
        public void monitoring_lace_external_source_no_response_received_consumer_consumed_must_be_true()
        {
            var message = new LaceExternalSourceNoResponseEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
                PublishableLaceMessages.NoResponseReceivedFromExternalSource, 0);

            var consumer = new ExternalSourceNoResponseReceivedConsumer(_persistEvent);
            consumer.Consume(message);
            consumer.HasBeenConsumed.ShouldBeTrue();
        }

        [Observation]
        public void monitoring_lace_external_source_response_received_consumer_consumed_must_be_true()
        {
            var message = new LaceExternalSourceResponseEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
                PublishableLaceMessages.ResponseReceivedFromExternalSource, string.Empty, 2);

            var consumer = new ExternalSourceReceivedResponseConsumer(_persistEvent);
            consumer.Consume(message);
            consumer.HasBeenConsumed.ShouldBeTrue();
        }

        [Observation]
        public void monitoring_lace_external_source_request_sent_consumer_consumed_must_be_true()
        {
            var message = new LaceExternalSourceRequestEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
               PublishableLaceMessages.RequestSentToExternalSource, string.Empty, 1);

            var consumer = new ExternalSourceSentRequestsConsumer(_persistEvent);
            consumer.Consume(message);
            consumer.HasBeenConsumed.ShouldBeTrue();
        }

        [Observation]
        public void monitoring_lace_external_source_response_transformed_consumer_consumed_must_true()
        {
            var message = new LaceTransformResponseEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
                PublishableLaceMessages.TransformingResponseFromExternalSourceHasStarted, 1);

            var consumer = new ExternalSourceTransformationConsumer(_persistEvent);
            consumer.Consume(message);
            consumer.HasBeenConsumed.ShouldBeTrue();
        }

    }
}