using System;
using EasyNetQ;
using Lace.Events.Messages;
using Lace.Shared.Enums;
using Workflow.BuildingBlocks;
using Xunit.Extensions;

namespace Lace.Events.Tests
{
    public class lace_log_event_ivid_source_tests : Specification
    {
        private readonly IBus _bus;
        private readonly ILaceEvent _laceEvent;
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


            _bus = new Mocks.MockSourceEventBus();
            //_bus = new BusFactory().CreateBus("LaceEventBus");
            _laceEvent = new PublishEvent(_bus);
        }

        public override void Observe()
        {
            try
            {
                _laceEvent.PublishMessage(_message);
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
    }
}
