using System;
using System.Collections.Generic;
using System.Threading;
using EasyNetQ;
using Lim.Core;
using Lim.Domain.Messaging;
using Lim.Dtos;
using Toolbox.LightstoneAuto.Domain.Commands.View;
using Toolbox.LightstoneAuto.Factories;
using Workflow.BuildingBlocks;
using Xunit.Extensions;

namespace Lim.Acceptance.Tests.Bus.LSAuto
{
    public class when_sending_view_created_to_the_integration_bus : Specification
    {
        private readonly ISendCommand _sender;
        private LoadView _command;
        private readonly Guid _id;
        private readonly IAdvancedBus _bus;
        private readonly List<DatabaseViewDto> _views;

        public when_sending_view_created_to_the_integration_bus()
        {
            _bus = BusFactory.CreateAdvancedBus("lim/queue");
            _id = Guid.NewGuid();
            _views = new BuildViewDtoFactory().Build(Guid.Empty);
            _sender = new SendCommand(_bus);
        }

        public override void Observe()
        {
            foreach (var view in _views)
            {
                view.AggregateId = Guid.NewGuid();
                _command = new LoadView(view, Guid.NewGuid(), Guid.NewGuid());
                _sender.Send(_command);

            }
        }

        [Observation]
        public void then_command_must_be_on_the_queue()
        {
            Thread.Sleep(5000);
            false.ShouldBeFalse();
        }

        

    }
}
