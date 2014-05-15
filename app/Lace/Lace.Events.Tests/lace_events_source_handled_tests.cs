using System;
using EasyNetQ;
using Lace.Events.Messages.Publish;
using Lace.Events.Tests.Consumers;
using Lace.Shared.Enums;
using Workflow;
using Workflow.BuildingBlocks;
using Workflow.BuildingBlocks.Consumers;
using Workflow.RabbitMQ;
using Xunit.Extensions;

namespace Lace.Events.Tests
{
    public class lace_events_source_handled_tests : Specification
    {

        private IBus _bus;
        private readonly BusFactory _factory;
        private readonly ConsumerRegistration _consumers;
        private IPublishMessages _publishMessages;

        private ILaceEvent _laceEvent;
        private Exception _exception;

        private readonly Guid _aggregateId;

        public lace_events_source_handled_tests()
        {
            _aggregateId = Guid.NewGuid();

            _factory = new BusFactory();
            _consumers = new ConsumerRegistration()
                 .AddConsumer<LaceEventMessageConsumer, ILaceEventMessage>(() => new LaceEventMessageConsumer());
        }
        

        public override void Observe()
        {
            try
            {

                using (_bus = _factory.CreateConsumerBus("LaceEventBus", _consumers))
                {
                    
                }

                _bus = _factory.CreateBus("LaceEventBus");
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

            _laceEvent.PublishSourceIsBeingHandledMessage(_aggregateId, EventSource.IvidSource);

            _laceEvent.PublishSourceIsNotBeingHandledMessage(_aggregateId, EventSource.IvidSource);
        }

        [Observation]
        public void lace_ivid_events_sources_responses_are_being_transformed_test()
        {
            _exception.ShouldBeNull();

            _bus.ShouldNotBeNull();

            _laceEvent.PublishTransformationFailedMessage(_aggregateId, EventSource.IvidSource);

            _laceEvent.PublishTransformationStartMessage(_aggregateId, EventSource.IvidSource);

            _laceEvent.PublishTransformationEndMessage(_aggregateId, EventSource.IvidSource);
        }
    }
}
