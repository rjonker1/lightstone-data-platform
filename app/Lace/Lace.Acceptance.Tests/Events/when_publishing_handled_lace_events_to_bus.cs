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
              
                _bus = new BusFactory().CreateBus("monitor-event-tracking/queue", new WindsorContainer());
                _publishMessages = new Publisher(_bus);
                _laceEvent = new PublishLaceEventMessages(_publishMessages);

            }
            catch (Exception e)
            {
                _exception = e;
            }
        }


        [Observation]
        public void when_lace_ivid_events_sources_handled_published()
        {
            _exception.ShouldBeNull();

            _bus.ShouldNotBeNull();

            _laceEvent.PublishSourceIsBeingHandledMessage(_aggregateId, ExternalSource.IvidSource);

            _laceEvent.PublishSourceIsNotBeingHandledMessage(_aggregateId, ExternalSource.IvidSource);
        }

        [Observation]
        public void when_lace_ivid_events_sources_responses_transformend_published()
        {
            _exception.ShouldBeNull();

            _bus.ShouldNotBeNull();

            _laceEvent.PublishTransformationFailedMessage(_aggregateId, ExternalSource.IvidSource);

            _laceEvent.PublishTransformationStartMessage(_aggregateId, ExternalSource.IvidSource);

            _laceEvent.PublishTransformationEndMessage(_aggregateId, ExternalSource.IvidSource);


            Thread.Sleep(5000);

            _bus.Dispose();
        }
    }
}
// ReSharper enable InconsistentNaming
