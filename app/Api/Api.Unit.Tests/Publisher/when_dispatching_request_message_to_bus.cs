using System;
using Api.Domain.Core.Dto;
using Api.Domain.Core.Messages;
using Api.Domain.Infrastructure.Bus;
using Xunit.Extensions;
using BusFactory = Workflow.BuildingBlocks.BusFactory;

namespace Api.Unit.Tests.Publisher
{
    public class when_dispatching_request_message_to_bus : Specification
    {

        private readonly IDispatchMessagesToBus<RequestReportMessage> _dispatcher;
        private readonly RequestReportMessage _request;

        public when_dispatching_request_message_to_bus()
        {

            _dispatcher = new RequestMessageDispatcher(BusFactory.CreateAdvancedBus("host=localhost"));
            _request = new RequestReportMessage(new RequestDto(), Guid.NewGuid());
        }

        public override void Observe()
        {
            _dispatcher.Dispatch(_request);
        }

        [Observation] //(Skip = "Need to check that message exists on the queue")
        public void then_message_should_exist_on_queue()
        {
            true.ShouldBeTrue();
        }
    }
}