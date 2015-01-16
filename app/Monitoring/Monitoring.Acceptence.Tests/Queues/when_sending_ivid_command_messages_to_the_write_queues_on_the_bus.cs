using System;
using DataPlatform.Shared.Enums;
using Monitoring.Queuing.Configuration;
using Monitoring.Queuing.Contracts;
using Monitoring.Queuing.RabbitMq;
using Monitoring.Test.Helper.Builder;
using Monitoring.Test.Helper.Messages;
using Monitoring.Test.Helper.Mothers;
using Monitoring.Test.Helper.Queues;
using Xunit.Extensions;

namespace Monitoring.Acceptance.Tests.Queues
{
    public class when_sending_ivid_command_messages_to_the_write_queues_on_the_bus : Specification
    {
        private readonly object _request;

        private readonly Guid _aggregateId;
        private readonly IHaveQueueActions _actions;

        public when_sending_ivid_command_messages_to_the_write_queues_on_the_bus()
        {
            var messageQueue = new RabbitMqMessageQueueing();
            _actions = new QueueActions(messageQueue.Consumer);

            _request = DataProviderRequestBuilder.ForLicensePlateSearch();
            _aggregateId = Guid.NewGuid();
        }

        public override void Observe()
        {
            var queue = new DataProviderQueueFunctions(_request, DataProviderCommandSource.Ivid, _actions, _aggregateId);
            queue.TearDown()
                .Setup()
                .InitBus(BusBuilder.ForIvidCommands(_aggregateId))
                .InitStopWatch()
                .StartingDataProviderMessage()
                .ConfigurationMessage(null)
                .SecurityMessage(DataProviderConfigurationBuiler.ForIvid(), null)
                .SecurityMessage(new
                {
                    Credentials =
                        new
                        {
                            UserName = "CARSTATS-CARSTATS",
                            Password = "8B5Jk3Q66"
                        }
                },
                new { ContextMessage = "Ivid Data Provider Credentials" })
                .StartCallingMessage()
                .FaultCallingMessage(new { NoRequestReceived = "No response received from Ivid Data Provider" })
                .EndCallingMessage(DataProviderResponseBuilder.FromIvid())
                .TransformationMessage(DataProviderTransformationBuilder.ForIvid(), new{ TrasformationMetaData = "Transforming Response from Ivid"})
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
