using System.Threading;
using Monitoring.Sources;
#pragma warning disable 169
//ReSharper disable InconsistentNaming
using System;
using EasyNetQ;
using Lace.Events.Messages.Publish;
using Workflow;
using Workflow.BuildingBlocks;
using Workflow.RabbitMQ;
using Xunit.Extensions;

namespace Lace.Events.Tests
{
    public class lace_events_source_handled_tests : Specification
    {

        private IBus _bus;
        private IPublishMessages _publishMessages;

        private ILaceEvent _laceEvent;
        private Exception _exception;

        private readonly Guid _aggregateId;

      //  private readonly ILaceEventService sourceEventService;

        public lace_events_source_handled_tests()
        {
            _aggregateId = Guid.NewGuid();

           // sourceEventService = new LaceEventService();

            //_factory = new BusFactory();
            //_consumers = new ConsumerRegistration()
            //     .AddConsumer<LaceEventMessageConsumer, ILaceEventMessage>(() => new LaceEventMessageConsumer());
        }
        

        public override void Observe()
        {
            try
            {
               // sourceEventService.Start();

                _bus = new BusFactory().CreateBus("monitor-event-tracking/queue");
                _publishMessages = new Publisher(_bus);
                _laceEvent = new PublishLaceEventMessages(_publishMessages);

            }
            catch (Exception e)
            {
                _exception = e;
            }
        }


        [Observation]
        public void lace_ivid_events_sources_are_handled_test()
        {
            _exception.ShouldBeNull();

            _bus.ShouldNotBeNull();

            _laceEvent.PublishSourceIsBeingHandledMessage(_aggregateId, FromSource.IvidSource);

            _laceEvent.PublishSourceIsNotBeingHandledMessage(_aggregateId, FromSource.IvidSource);
        }

        [Observation]
        public void lace_ivid_events_sources_responses_are_being_transformed_test()
        {
            _exception.ShouldBeNull();

            _bus.ShouldNotBeNull();

            _laceEvent.PublishTransformationFailedMessage(_aggregateId, FromSource.IvidSource);

            _laceEvent.PublishTransformationStartMessage(_aggregateId, FromSource.IvidSource);

            _laceEvent.PublishTransformationEndMessage(_aggregateId, FromSource.IvidSource);


            Thread.Sleep(5000);

            _bus.Dispose();
        }
    }
}
// ReSharper enable InconsistentNaming
#pragma warning restore 169