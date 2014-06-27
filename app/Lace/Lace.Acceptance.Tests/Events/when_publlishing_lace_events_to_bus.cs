using System;
using System.Threading;
using EasyNetQ;
using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Extensions;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Mothers.Requests;
using Monitoring.Sources.Lace;
using Workflow;
using Workflow.BuildingBlocks;
using Workflow.RabbitMQ;
using Xunit.Extensions;


// ReSharper disable InconsistentNaming



namespace Lace.Acceptance.Tests.Events
{
    public class lace_log_event_ivid_source_tests : Specification
    {
        private IBus _bus;
        private IPublishMessages _publishMessages;

        private ILaceEvent _laceEvent;
        private Exception _exception;
        private readonly Guid _aggregateId;

        public lace_log_event_ivid_source_tests()
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
                _laceEvent = new PublishLaceEventMessages(_publishMessages,_aggregateId);

            }
            catch (Exception e)
            {
                _exception = e;
            }
        }

        [Observation]
        public void lace_ivid_events_services_must_be_published_to_message_queue()
        {
            _exception.ShouldBeNull();

            _bus.ShouldNotBeNull();

            _laceEvent.PublishLaceReceivedRequestMessage(LaceEventSource.EntryPoint);

            _laceEvent.PublishStartServiceConfigurationMessage(LaceEventSource.Ivid);

            _laceEvent.PublishEndServiceConfigurationMessage(LaceEventSource.Ivid);

            _laceEvent.PublishStartServiceCallMessage(LaceEventSource.Ivid);

            _laceEvent.PublishEndServiceCallMessage(LaceEventSource.Ivid);

            _laceEvent.PublishServiceRequestMessage(LaceEventSource.Ivid, new LicensePlateNumberIvidOnlyRequest().ObjectToJson());

            _laceEvent.PublishServiceResponseMessage(LaceEventSource.Ivid, new LicensePlateRequestBuilder().ForIvid().ObjectToJson());

            _laceEvent.PublishFailedServiceCallMessaage(LaceEventSource.Ivid);

            _laceEvent.PublishNoResponseFromServiceMessage(LaceEventSource.Ivid);

            _laceEvent.PublishLaceReceivedRequestMessage(LaceEventSource.Initialization);


            Thread.Sleep(5000);

            _bus.Dispose();
        }

    }
}
// ReSharper enable InconsistentNaming

