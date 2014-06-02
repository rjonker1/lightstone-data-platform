using Monitoring.Sources;
#pragma warning disable 169
// ReSharper disable InconsistentNaming
using System;
using System.Threading;
using EasyNetQ;
using Lace.Events.Messages.Publish;
using Lace.Functions.Json;
using Workflow;
using Workflow.BuildingBlocks;
using Workflow.RabbitMQ;
using Xunit.Extensions;

namespace Lace.Events.Tests
{
    public class lace_log_event_ivid_source_tests : Specification
    {
        private IBus _bus;
        private IPublishMessages _publishMessages;

        private ILaceEvent _laceEvent;
        private Exception _exception;
        //private readonly ILaceEventService _sourceEventService;
        private readonly Guid _aggregateId;

        public lace_log_event_ivid_source_tests()
        {
            
            _aggregateId = Guid.NewGuid();
            //_sourceEventService = new LaceEventService();
            //_factory = new BusFactory();
            //_consumers = new ConsumerRegistration()
            //     .AddConsumer<LaceEventMessageConsumer, ILaceEventMessage>(() => new LaceEventMessageConsumer());
        }

        public override void Observe()
        {
            try
            {

                //using (_bus = _factory.CreateConsumerBus("LaceEventBus", _consumers))
                //{
                    
                //}
                //_sourceEventService.Start();
                _bus = new BusFactory().CreateBus("LaceEventBus");
                _publishMessages = new Publisher(_bus);
                _laceEvent = new PublishLaceEventMessages(_publishMessages);

            }
            catch (Exception e)
            {
                _exception = e;
            }
        }

        [Observation]
        public void lace_ivid_events_services_to_message_queue_test()
        {
            _exception.ShouldBeNull();

            _bus.ShouldNotBeNull();

            _laceEvent.PublishStartServiceConfigurationMessage(_aggregateId, FromSource.IvidSource);

            _laceEvent.PublishEndServiceConfigurationMessage(_aggregateId, FromSource.IvidSource);

            _laceEvent.PublishStartServiceCallMessage(_aggregateId, FromSource.IvidSource);

            _laceEvent.PublishEndServiceCallMessage(_aggregateId, FromSource.IvidSource);

            _laceEvent.PublishServiceRequestMessage(_aggregateId, FromSource.IvidSource, JsonFunctions.JsonFunction.ObjectToJson(new Source.Tests.Data.LicensePlateNumberIvidOnlyRequest()));

            _laceEvent.PublishServiceResponseMessage(_aggregateId, FromSource.IvidSource, JsonFunctions.JsonFunction.ObjectToJson(Source.Tests.Data.Ivid.MockIvidLicensePlateNumberRequestData.GetLicensePlateNumberRequestForIvid()));

            _laceEvent.PublishFailedServiceCallMessaage(_aggregateId, FromSource.IvidSource);

            _laceEvent.PublishNoResponseFromServiceMessage(_aggregateId, FromSource.IvidSource);


            Thread.Sleep(5000);

            _bus.Dispose();
        }

    }
}
// ReSharper enable InconsistentNaming
#pragma warning restore 169

