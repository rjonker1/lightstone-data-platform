using System;
using System.Linq;
using System.Threading;
using EasyNetQ;
using Lim.Core;
using Lim.Domain.Entities;
using Lim.Domain.Entities.Repository;
using Lim.Domain.Messaging.Messages;
using Lim.Domain.Messaging.Publishing;
using Lim.Entities;
using Lim.Test.Helper.Fakes;
using Workflow.BuildingBlocks;
using Xunit.Extensions;

namespace Lim.Acceptance.Tests.Bus
{
    public class when_sending_package_response_to_integration_queue : Specification
    {
        private readonly IPublishIntegrationMessages _publisher;
        private readonly PackageResponseMessage _message;
        private readonly Guid _requestId;
        private readonly IAdvancedBus _bus;
        private Exception _exception;

        private readonly IRepository _repository;

        private readonly Guid _packageId = new Guid("390CD416-FC52-4A0B-98CE-8E8940212354");
        private readonly Guid _userId = new Guid("A8085D55-DF0E-4875-A81C-26892126C01C");
        private readonly Guid _contractId = new Guid("B63F6F0C-D26A-4959-9E75-7C8C485CC495");
        private readonly string _accountNumber = "Int00001";
        private readonly string _payload = FakeResponse.JsonFromPackage();

        public when_sending_package_response_to_integration_queue()
        {
            _bus = BusFactory.CreateAdvancedBus("lim/queue");
            _requestId = Guid.NewGuid();
            _message = new PackageResponseMessage(_packageId, _userId, _contractId, _accountNumber, _payload, _requestId, "rudi@customapp.co.za");
            _publisher = new IntegrationMessagePublisher(_bus);

            //_repository = new LimRepository(SessionFactory.BuildSession("lim/schedule/database").OpenSession());
            _repository = new LimRepository();
        }

        public override void Observe()
        {
            try
            {
                _publisher.SendToBus(_message);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Observation]
        public void then_message_needs_to_be_sent_to_queue()
        {
            Thread.Sleep(5000);
            _exception.ShouldBeNull();
        }

        [Observation]
        public void then_response_should_exist_in_the_database()
        {
            var response = _repository.Get<PackageResponses>(w => w.RequestId == _requestId).ToList();
            response.ShouldNotBeNull();
            response.Count.ShouldEqual(1);
            response.FirstOrDefault().RequestId.ShouldEqual(_requestId);
        }
    }
}
