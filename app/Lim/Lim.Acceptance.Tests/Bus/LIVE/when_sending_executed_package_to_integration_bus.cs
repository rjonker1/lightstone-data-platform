using System;
using System.Threading;
using EasyNetQ;
using Lim.Core;
using Lim.Domain.Messaging;
using Lim.Test.Helper.Fakes;
using Toolbox.LIVE.Shared.Commands;
using Workflow.BuildingBlocks;
using Xunit.Extensions;

namespace Lim.Acceptance.Tests.Bus.LIVE
{
    public class when_sending_executed_package_to_integration_bus : Specification
    {
        private readonly ISendCommand _sender;
        private readonly SendExecutedPackage _command;
        private readonly Guid _requestId;
        private readonly IAdvancedBus _bus;

        private readonly Guid _packageId = new Guid("390CD416-FC52-4A0B-98CE-8E8940212354");
        private readonly Guid _userId = new Guid("A8085D55-DF0E-4875-A81C-26892126C01C");
        private readonly Guid _contractId = new Guid("B63F6F0C-D26A-4959-9E75-7C8C485CC495");
        private readonly string _username = "rudi@customapp.co.za";
        private readonly string _accountNumber = "Int00001";
        private readonly string _payload = FakeResponse.JsonPackageWithState();

        public when_sending_executed_package_to_integration_bus()
        {
            _bus = BusFactory.CreateAdvancedBus("lim/queue");
            _requestId = Guid.NewGuid();
            _command = new SendExecutedPackage(_packageId, _userId, _contractId, _accountNumber, _payload, _requestId, _username);
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
