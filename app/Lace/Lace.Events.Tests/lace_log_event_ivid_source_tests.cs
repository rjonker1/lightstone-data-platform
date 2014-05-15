﻿using System;
using EasyNetQ;
using Lace.Events.Messages;
using Lace.Events.Messages.Publish;
using Lace.Events.Tests.Consumers;
using Lace.Functions.Json;
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
        private Exception _exception;

        private readonly Guid _aggregateId;

        public lace_log_event_ivid_source_tests()
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
        public void lace_ivid_events_services_to_message_queue_test()
        {
            _exception.ShouldBeNull();

            _bus.ShouldNotBeNull();

            _laceEvent.PublishStartServiceConfigurationMessage(_aggregateId, EventSource.IvidSource);

            _laceEvent.PublishEndServiceConfigurationMessage(_aggregateId, EventSource.IvidSource);

            _laceEvent.PublishStartServiceCallMessage(_aggregateId, EventSource.IvidSource);

            _laceEvent.PublishEndServiceCallMessage(_aggregateId, EventSource.IvidSource);

            _laceEvent.PublishServiceRequestMessage(_aggregateId, EventSource.IvidSource, JsonFunctions.JsonFunction.ObjectToJson(new Source.Tests.Data.LicensePlateNumberIvidOnlyRequest()));

            _laceEvent.PublishServiceResponseMessage(_aggregateId, EventSource.IvidSource, JsonFunctions.JsonFunction.ObjectToJson(Source.Tests.Data.Ivid.MockIvidLicensePlateNumberRequestData.GetLicensePlateNumberRequestForIvid()));

            _laceEvent.PublishFailedServiceCallMessaage(_aggregateId, EventSource.IvidSource);

            _laceEvent.PublishNoResponseFromServiceMessage(_aggregateId, EventSource.IvidSource);
        }

    }
}
