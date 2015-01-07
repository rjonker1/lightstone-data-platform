using System;
using DataPlatform.Shared.Enums;
using Lace.Shared.Monitoring.Messages.Core;
using Monitoring.Queuing.Configuration;
using Monitoring.Queuing.Contracts;
using Monitoring.Queuing.RabbitMq;
using Monitoring.Test.Helper.Builder;
using Monitoring.Test.Helper.Messages;
using Monitoring.Test.Helper.Queues;
using Xunit.Extensions;

namespace Monitoring.Acceptance.Tests.Queues
{
    public class when_sending_ivid_command_messages_to_the_write_queues_on_the_bus : Specification
    {
        private readonly string _request;

        private readonly Guid _aggregateId;
        private readonly IHaveQueueActions _actions;

        public when_sending_ivid_command_messages_to_the_write_queues_on_the_bus()
        {
            var messageQueue = new RabbitMqMessageQueueing();
            _actions = new QueueActions(messageQueue.Consumer);

            _request = DataProviderRequestBuilder.ForIvid();
            _aggregateId = Guid.NewGuid();
        }

        public override void Observe()
        {
            var queue = new DataProviderQueueFunctions(_request, DataProviderCommandSource.Ivid, _actions, _aggregateId);
            queue.TearDown()
                .Setup()
                .InitBus()
                .InitStopWatch()
                .StartingDataProviderMessage()
                .ConfigurationMessage(string.Empty)
                .SecurityMessage(DataProviderConfigurationBuiler.ForIvid(), "Ivid Data Provider Credentials")
                .StartCallingMessage()
                .FaultCallingMessage("No response received from Ivid Data Provider")
                .EndCallingMessage(DataProviderResponseBuilder.FromIvid())
                .TransformationMessage(DataProviderTransformationBuilder.ForIvid(), "Transforming Response from Ivid")
                .EndingDataProvider();
        }

        [Observation]
        public void then_ivid_messages_should_be_put_on_the_correct_write_queue()
        {
            var messageCount = _actions.GetMessageCount(ConfigureMonitoringWriteQueues.ForHost().ExchangeName,
                ConfigureMonitoringWriteQueues.ForHost().QueueName, ConfigureMonitoringWriteQueues.ForHost().RoutingKey,
                ConfigureMonitoringWriteQueues.ForHost().ExchangeType);
            messageCount.ShouldEqual(8);

        }
    }
}
