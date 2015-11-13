using System;
using Billing.TestHelper.BaseTests;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Xunit.Extensions;

namespace Billing.Api.Tests.Consumers.EasyNetQ
{
    public class when_publishing_new_transaction_request_to_queue: BaseTestHelper
    {
        private readonly IAdvancedBus _bus;
        private TransactionRequestMessage transaction;

        public when_publishing_new_transaction_request_to_queue()
        {
            _bus = Container.Resolve<IAdvancedBus>();
        }

        public override void Observe()
        {

        }

        [Observation]
        public void it_should_publish_a_successful_vin12_transaction()
        {
            var bus = new TransactionBus(_bus);

            transaction = new TransactionRequestMessage
            {
                RequestId = new Guid("8E250190-EE28-40D6-92B8-042B67B98F7C"),
                UserState = ApiCommitRequestUserState.Successful
            };

            bus.SendDynamic(transaction);

            _bus.ShouldNotBeNull();
        }

        [Observation]
        public void it_should_publish_a_vehicle_not_provided_vin12_transaction()
        {
            var bus = new TransactionBus(_bus);

            transaction = new TransactionRequestMessage
            {
                RequestId = new Guid("8E250190-EE28-40D6-92B8-042B67B98F7C"),
                UserState = ApiCommitRequestUserState.VehicleNotProvided
            };

            bus.SendDynamic(transaction);

            _bus.ShouldNotBeNull();
        }

        [Observation]
        public void it_should_publish_a_cancelled_vin12_transaction()
        {
            var bus = new TransactionBus(_bus);

            transaction = new TransactionRequestMessage
            {
                RequestId = new Guid("8E250190-EE28-40D6-92B8-042B67B98F7C"),
                UserState = ApiCommitRequestUserState.Cancelled
            };

            bus.SendDynamic(transaction);

            _bus.ShouldNotBeNull();
        }
    }
}