using System;
using System.Threading;
using Lace.Shared.Monitoring.Messages.Shared;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Events
{
    public class when_publishing_handled_lace_events_to_bus : Specification
    {

        private ISendMonitoringMessages _laceEvent;
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
              
                
                //_bus = BusFactory.CreateBus("monitor-event-tracking/queue");
                //_publishMessages = new Publisher(_bus);
               // _laceEvent = new PublishLaceEventMessages(_publishMessages,_aggregateId);
                throw new Exception("Bus not implemented");
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

            //_bus.ShouldNotBeNull();

            //_laceEvent.PublishSourceIsBeingHandledMessage(LaceEventSource.Ivid);

            //_laceEvent.PublishSourceIsNotBeingHandledMessage(LaceEventSource.Ivid);
        }

        [Observation]
        public void lace_ivid_source_events_response_being_transformend_must_be_published()
        {
            _exception.ShouldBeNull();

           // _bus.ShouldNotBeNull();

            //_laceEvent.PublishTransformationFailedMessage(LaceEventSource.Ivid);

            //_laceEvent.PublishTransformationStartMessage(LaceEventSource.Ivid);

            //_laceEvent.PublishTransformationEndMessage(LaceEventSource.Ivid);


            Thread.Sleep(5000);

            //_bus.Dispose();
        }
    }
}
