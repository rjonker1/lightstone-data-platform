using System;
using EventTracking.Domain.Persistence.EventStore;
using Monitoring.Consumer.Lace.Consumers;
using Monitoring.Consumer.Lace.Messages;
using Monitoring.Sources.Lace;
using Xunit.Extensions;

#pragma warning disable 169
//ReSharper disable InconsistentNaming

namespace Monitoring.Unit.Tests.Lace.Consumer
{
    //public class when_external_source_gets_consumed : Specification
    //{

    //    public override void Observe()
    //    {

    //    }


    //    [Observation]
    //    public void monitoring_lace_external_source_conumer_consumed_must_be_true()
    //    {
    //        var message = new LaceExternalSourceExecutionEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
    //            PublishableLaceMessages.StartCallingExternalSource,1);

    //        var consumer = new ExternalSourceExecutedConsumer(new PersistEvent());
    //        consumer.Consume(message);
    //        consumer.HasBeenConsumed.ShouldBeTrue();


    //        message = new LaceExternalSourceExecutionEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
    //           PublishableLaceMessages.EndCallingExternalSource,2);

    //       // consumer = new ExternalSourceConsumer();
    //        consumer.Consume(message);
    //        consumer.HasBeenConsumed.ShouldBeTrue();
    //    }

       
    //    [Observation]
    //    public void monitoring_lace_external_source_configuration_consumer_consumed_must_be_true()
    //    {
    //        var message = new LaceExternalSourceConfigurationEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
    //            PublishableLaceMessages.StartConfigurationForExternalSource,1);

    //        var consumer = new ExternalSourceConfigurationConsumer(new PersistEvent());
    //        consumer.Consume(message);
    //        consumer.HasBeenConsumed.ShouldBeTrue();
    //    }

    //    [Observation]
    //    public void monitoring_lace_external_source_failed_consumer_consumed_must_be_true()
    //    {
    //        var message = new LaceExternalSourceFailedEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
    //           PublishableLaceMessages.ExternalSourceCallFailed,0);

    //        var consumer = new ExternalSourceFailedConsumer(new PersistEvent());
    //        consumer.Consume(message);
    //        consumer.HasBeenConsumed.ShouldBeTrue();
    //    }

    //    [Observation]
    //    public void monitoring_lace_external_source_handled_consumer_consumed_must_be_truee()
    //    {
    //        var message = new LaceSourceHandledEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
    //            PublishableLaceMessages.ExternalSourceIsBeingHandled,0);

    //        var consumer = new ExternalSourceHandledConsumer(new PersistEvent());
    //        consumer.Consume(message);
    //        consumer.HasBeenConsumed.ShouldBeTrue();
    //    }

    //    [Observation]
    //    public void monitoring_lace_external_source_no_response_received_consumer_consumed_must_be_true()
    //    {
    //        var message = new LaceExternalSourceNoResponseEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
    //            PublishableLaceMessages.NoResponseReceivedFromExternalSource,0);

    //        var consumer = new ExternalSourceNoResponseReceivedConsumer(new PersistEvent());
    //        consumer.Consume(message);
    //        consumer.HasBeenConsumed.ShouldBeTrue();
    //    }

    //    [Observation]
    //    public void monitoring_lace_external_source_response_received_consumer_consumed_must_be_true()
    //    {
    //        var message = new LaceExternalSourceResponseEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
    //            PublishableLaceMessages.ResponseReceivedFromExternalSource, string.Empty,2);

    //        var consumer = new ExternalSourceReceivedResponseConsumer(new PersistEvent());
    //        consumer.Consume(message);
    //        consumer.HasBeenConsumed.ShouldBeTrue();
    //    }

    //    [Observation]
    //    public void monitoring_lace_external_source_request_sent_consumer_consumed_must_be_true()
    //    {
    //        var message = new LaceExternalSourceRequestEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
    //           PublishableLaceMessages.RequestSentToExternalSource, string.Empty,1);

    //        var consumer = new ExternalSourceSentRequestsConsumer(new PersistEvent());
    //        consumer.Consume(message);
    //        consumer.HasBeenConsumed.ShouldBeTrue();
    //    }

    //    [Observation]
    //    public void monitoring_lace_external_source_response_transformed_consumer_consumed_must_true()
    //    {
    //        var message = new LaceTransformResponseEventMessage(Guid.NewGuid(), LaceEventSource.Ivid,
    //            PublishableLaceMessages.TransformingResponseFromExternalSourceHasStarted,1);

    //        var consumer = new ExternalSourceTransformationConsumer(new PersistEvent());
    //        consumer.Consume(message);
    //        consumer.HasBeenConsumed.ShouldBeTrue();
    //    }

    //}
}

//ReSharper enable InconsistentNaming
#pragma warning restore 169