using System;
using System.Threading;
using Castle.Windsor;
using EasyNetQ;
using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Functions.Json;
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
                _laceEvent = new PublishLaceEventMessages(_publishMessages);

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

            _laceEvent.PublishLaceReceivedRequestMessage(_aggregateId, LaceEventSource.EntryPoint);

            _laceEvent.PublishStartServiceConfigurationMessage(_aggregateId, LaceEventSource.Ivid);

            _laceEvent.PublishEndServiceConfigurationMessage(_aggregateId, LaceEventSource.Ivid);

            _laceEvent.PublishStartServiceCallMessage(_aggregateId, LaceEventSource.Ivid);

            _laceEvent.PublishEndServiceCallMessage(_aggregateId, LaceEventSource.Ivid);

            _laceEvent.PublishServiceRequestMessage(_aggregateId, LaceEventSource.Ivid, JsonFunctions.JsonFunction.ObjectToJson(new LicensePlateNumberIvidOnlyRequest()));

            _laceEvent.PublishServiceResponseMessage(_aggregateId, LaceEventSource.Ivid, JsonFunctions.JsonFunction.ObjectToJson(new LicensePlateRequestBuilder().ForIvid()));

            _laceEvent.PublishFailedServiceCallMessaage(_aggregateId, LaceEventSource.Ivid);

            _laceEvent.PublishNoResponseFromServiceMessage(_aggregateId, LaceEventSource.Ivid);

            _laceEvent.PublishLaceReceivedRequestMessage(_aggregateId, LaceEventSource.Initialization);


            Thread.Sleep(5000);

            _bus.Dispose();
        }

    }
}
// ReSharper enable InconsistentNaming

