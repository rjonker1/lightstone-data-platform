using System;
using Monitoring.Consumer.Lace.Consumers;
using Monitoring.Consumer.Lace.Messages;
using Monitoring.Sources.Lace;
using Xunit.Extensions;

#pragma warning disable 169
//ReSharper disable InconsistentNaming

namespace Monitoring.Unit.Tests.Lace.Consumer
{
    public class when_external_source_gets_consumed : Specification
    {

        public override void Observe()
        {

        }


        [Observation]
        public void monitoring_lace_external_source_conumer_consumed_must_be_true()
        {
            var message = new LaceExternalSourceEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
                PublishableLaceMessages.StartCallingExternalSource() );

            var consumer = new ExternalSourceConsumer();
            consumer.Consume(message);
            consumer.HasBeenConsumed.ShouldBeTrue();


            message = new LaceExternalSourceEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
               PublishableLaceMessages.EndCallingExternalSource());

           // consumer = new ExternalSourceConsumer();
            consumer.Consume(message);
            consumer.HasBeenConsumed.ShouldBeTrue();
        }

       
        [Observation]
        public void monitoring_lace_external_source_configuration_consumer_consumed_must_be_true()
        {
            var message = new LaceExternalSourceConfigurationEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
                PublishableLaceMessages.StartConfigurationForExternalSource());

            var consumer = new ExternalSourceConfigurationConsumer();
            consumer.Consume(message);
            consumer.HasBeenConsumed.ShouldBeTrue();
        }

        [Observation]
        public void monitoring_lace_external_source_failed_consumer_consumed_must_be_true()
        {
            var message = new LaceExternalSourceFailedEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
               PublishableLaceMessages.ExternalSourceCallFailed());

            var consumer = new ExternalSourceFailedConsumer();
            consumer.Consume(message);
            consumer.HasBeenConsumed.ShouldBeTrue();
        }

        [Observation]
        public void monitoring_lace_external_source_handled_consumer_consumed_must_be_truee()
        {
            var message = new LaceSourceHandledEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
                PublishableLaceMessages.ExternalSourceIsBeingHandled());

            var consumer = new ExternalSourceHandledConsumer();
            consumer.Consume(message);
            consumer.HasBeenConsumed.ShouldBeTrue();
        }

        [Observation]
        public void monitoring_lace_external_source_no_response_received_consumer_consumed_must_be_true()
        {
            var message = new LaceExternalSourceNoResponseEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
                PublishableLaceMessages.NoResponseReceivedFromExternalSource());

            var consumer = new ExternalSourceNoResponseReceivedConsumer();
            consumer.Consume(message);
            consumer.HasBeenConsumed.ShouldBeTrue();
        }

        [Observation]
        public void monitoring_lace_external_source_response_received_consumer_consumed_must_be_true()
        {
            var message = new LaceExternalSourceResponseEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
                PublishableLaceMessages.ResponseReceivedFromExternalSource(), string.Empty);

            var consumer = new ExternalSourceReceivedResponseConsumer();
            consumer.Consume(message);
            consumer.HasBeenConsumed.ShouldBeTrue();
        }

        [Observation]
        public void monitoring_lace_external_source_request_sent_consumer_consumed_must_be_true()
        {
            var message = new LaceExternalSourceRequestEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
               PublishableLaceMessages.RequestSentToExternalSource(), string.Empty);

            var consumer = new ExternalSourceSentRequestsConsumer();
            consumer.Consume(message);
            consumer.HasBeenConsumed.ShouldBeTrue();
        }

        [Observation]
        public void monitoring_lace_external_source_response_transformed_consumer_consumed_must_true()
        {
            var message = new LaceTransformResponseEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
                PublishableLaceMessages.TransformingResponseFromExternalSourceHasStarted());

            var consumer = new ExternalSourceTransformationConsumer();
            consumer.Consume(message);
            consumer.HasBeenConsumed.ShouldBeTrue();
        }

    }
}

//ReSharper enable InconsistentNaming
#pragma warning restore 169