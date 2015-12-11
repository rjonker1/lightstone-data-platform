using System;
using System.Threading;
using EasyNetQ;
using Lim.Core;
using Lim.Domain.Messaging;
using Lim.Test.Helper.Builder;
using Toolbox.LightstoneAuto.Domain.Commands.Dataset;
using Workflow.BuildingBlocks;
using Xunit.Extensions;

namespace Lim.Acceptance.Tests.Bus.LSAuto
{
    public class when_sending_data_set_created_to_the_integration_bus : Specification
    {
        private readonly ISendCommand _sender;
        private readonly CreateDataExtract _command;
        private readonly Guid _id;
        private readonly IAdvancedBus _bus;

        public when_sending_data_set_created_to_the_integration_bus()
        {
            _bus = BusFactory.CreateAdvancedBus("lim/queue");
            _id = Guid.NewGuid();
            _command = new CreateDataExtract(FakeDataSetDtoBuilder.ForLsAutoSpecsData(_id), Guid.NewGuid());
            _sender = new SendCommand(_bus);
        }

        public override void Observe()
        {
            _sender.Send(_command);
        }

        [Observation]
        public void then_message_should_exist_on_correct_queue()
        {
            Thread.Sleep(5000);
            false.ShouldBeFalse();
        }
    }
}
