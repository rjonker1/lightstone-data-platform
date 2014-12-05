using System;
using System.Threading;
using Lace.Shared.Monitoring.Messages.Shared;
using NServiceBus;
using NServiceBus.Transports;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Events
{
    public class lace_log_event_ivid_source_tests : Specification
    {
        private IBus _bus;
        private IPublishMessages _publishMessages;

        private ISendMonitoringMessages _laceEvent;
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
                //_bus = BusFactory.CreateBus("monitor-event-tracking/queue");
                //_publishMessages = new Publisher(_bus);
               // _laceEvent = new PublishLaceEventMessages(_publishMessages,_aggregateId);

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

            //_laceEvent.PublishLaceReceivedRequestMessage(LaceEventSource.EntryPoint);

            //_laceEvent.PublishStartSourceConfigurationMessage(LaceEventSource.Ivid);

            //_laceEvent.PublishEndSourceConfigurationMessage(LaceEventSource.Ivid);

            //_laceEvent.PublishStartSourceCallMessage(LaceEventSource.Ivid);

            //_laceEvent.PublishEndSourceCallMessage(LaceEventSource.Ivid);

            //_laceEvent.PublishSourceRequestMessage(LaceEventSource.Ivid, new LicensePlateNumberIvidOnlyRequest().ObjectToJson());

            //_laceEvent.PublishSourceResponseMessage(LaceEventSource.Ivid, new LicensePlateRequestBuilder().ForIvid().ObjectToJson());

            //_laceEvent.PublishFailedSourceCallMessage(LaceEventSource.Ivid);

            //_laceEvent.PublishNoResponseFromSourceMessage(LaceEventSource.Ivid);

            //_laceEvent.PublishLaceReceivedRequestMessage(LaceEventSource.Initialization);


            Thread.Sleep(5000);

            _bus.Dispose();
        }

    }
}

