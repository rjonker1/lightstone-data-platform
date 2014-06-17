using System;
using System.Threading;
using Castle.Windsor;
using EasyNetQ;
using Lace.Events;
using Lace.Events.Messages.Publish;
using Monitoring.Sources.Lace;
using Workflow;
using Workflow.BuildingBlocks;
using Workflow.RabbitMQ;
using Xunit.Extensions;
//ReSharper disable InconsistentNaming

namespace Lace.Acceptance.Tests.Events
{
    public class when_publishing_handled_lace_events_to_bus : Specification
    {

        private IBus _bus;
        private IPublishMessages _publishMessages;

        private ILaceEvent _laceEvent;
        private Exception _exception;

        private readonly Guid _aggregateId;

        public when_publishing_handled_lace_events_to_bus()
        {
            _aggregateId = Guid.NewGuid();
        }
        

        public override void Observe()
        {
            try
            {
              
                //_bus = new BusFactory().CreateBus("monitor-event-tracking/queue", new WindsorContainer());
                _bus = BusFactory.CreateBus("monitor-event-tracking/queue");
                _publishMessages = new Publisher(_bus);
                _laceEvent = new PublishLaceEventMessages(_publishMessages);

            }
            catch (Exception e)
            {
                _exception = e;
            }
        }


        [Observation]
        public void lace_ivid_source_events_handled_must_be_published()
        {
            _exception.ShouldBeNull();

            _bus.ShouldNotBeNull();

            _laceEvent.PublishSourceIsBeingHandledMessage(_aggregateId, LaceEventSource.Ivid);

            _laceEvent.PublishSourceIsNotBeingHandledMessage(_aggregateId, LaceEventSource.Ivid);
        }

        [Observation]
        public void lace_ivid_source_events_response_being_transformend_must_be_published()
        {
            _exception.ShouldBeNull();

            _bus.ShouldNotBeNull();

            _laceEvent.PublishTransformationFailedMessage(_aggregateId, LaceEventSource.Ivid);

            _laceEvent.PublishTransformationStartMessage(_aggregateId, LaceEventSource.Ivid);

            _laceEvent.PublishTransformationEndMessage(_aggregateId, LaceEventSource.Ivid);


            Thread.Sleep(5000);

            _bus.Dispose();
        }
    }
}
// ReSharper enable InconsistentNaming
