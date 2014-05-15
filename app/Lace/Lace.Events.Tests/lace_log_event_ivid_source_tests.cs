using System;
using EasyNetQ;
using Lace.Events.Messages;
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
    public class lace_log_event_ivid_source_tests : Specification
    {
        private IBus _bus;
        private readonly BusFactory _factory;
        private readonly ConsumerRegistration _consumers;
        private IPublishMessages _publishMessages;

        private ILaceEvent _laceEvent;
        private readonly LaceEventMessage _message;
        private Exception _exception;

        public lace_log_event_ivid_source_tests()
        {
            _message = new LaceEventMessage()
            {
                AggregateId = Guid.NewGuid(),
                Message = "Ivid Event Test Message",
                Source = EventSource.IvidSource
            };

            _factory = new BusFactory();
            _consumers = new ConsumerRegistration()
                .AddConsumer<LaceEventMessageConsumer, LaceEventMessage>(() => new LaceEventMessageConsumer());

            //var bus = new Mocks.MockSourceEventBus();
            //var bus = new BusFactory().CreateConsumerBus()
            //var publisher = new Workflow.RabbitMQ.Publisher(bus);
           // _laceEvent = new PublishLaceEventMessages(publisher);

            //_bus = new Mocks.MockSourceEventBus();
            // _bus = new BusFactory().CreateBus("LaceEventBus");

        }

        public override void Observe()
        {
            try
            {

                using (_bus = _factory.CreateConsumerBus("LaceEventBus", _consumers))
                {
                    _publishMessages = new Publisher(_bus);
                    _laceEvent = new PublishLaceEventMessages(_publishMessages);
                    _laceEvent.PublishMessage(_message);
                }
            }
            catch (Exception e)
            {
                _exception = e;
            }
        }

        [Observation]
        public void lace_logged_event_from_ivid_exception_must_be_null_test()
        {
            _exception.ShouldBeNull();
        }

        [Observation]
        public void lace_event_the_bus_must_be_created()
        {
            _bus.ShouldNotBeNull();
        }
    }
}
