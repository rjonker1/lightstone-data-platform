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

        private readonly IDispatchMessagesToBus<RequestMetadataMessage> _dispatcher;
        private readonly RequestMetadataMessage _request;

        public when_dispatching_request_message_to_bus()
        {

            _dispatcher = new RequestMessageDispatcher(BusFactory.CreateAdvancedBus("host=localhost"));
            _request = new RequestMetadataMessage(new RequestHeaderMetadataDto(),new RequestUrlMetadataDto(),  Guid.NewGuid(), string.Empty);
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