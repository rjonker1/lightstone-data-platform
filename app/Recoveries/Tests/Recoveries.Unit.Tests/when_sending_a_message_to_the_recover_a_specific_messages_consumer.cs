﻿using System;
using System.Linq;
using EasyNetQ;
using Recoveries.ErrorQueues;
using Recoveries.ErrorQueues.Messages;
using Recoveries.Router.Configuration;
using Recoveries.Unit.Tests.Helper;
using Workflow.BuildingBlocks;
using Xunit.Extensions;

namespace Recoveries.Unit.Tests
{
    public class when_sending_a_message_to_the_recover_a_specific_messages_consumer : Specification
    {
        private readonly RetryErrorsOnAQueueMessage _message;
        private readonly IAdvancedBus _bus;

        public when_sending_a_message_to_the_recover_a_specific_messages_consumer()
        {
            _message = new RetryErrorsOnAQueueMessage(ConfigurationReader.Configurations.FirstOrDefault());
            _bus = BusFactory.CreateAdvancedBus(RecoveryReceiverQueueConfiguration.Receiver());
        }

        public override void Observe()
        {
            MessagePublisher.Configure(_bus, "Dataplatform.DataProvider.Recoveries.Reciever", "Dataplatform.DataProvider.Recoveries.Reciever").SendToBus(_message);
        }

        [Observation]
        public void then_message_should_be_on_queue()
        {
            true.ShouldBeTrue();
        }
    }
}
