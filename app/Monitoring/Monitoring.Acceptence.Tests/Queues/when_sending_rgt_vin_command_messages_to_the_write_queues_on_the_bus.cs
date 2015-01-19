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
    public class when_sending_rgt_vin_command_messages_to_the_write_queues_on_the_bus : Specification
    {
        private readonly object _request;

        private readonly Guid _aggregateId;
        private readonly IHaveQueueActions _actions;

        public when_sending_rgt_vin_command_messages_to_the_write_queues_on_the_bus()
        {
            var messageQueue = new RabbitMqMessageQueueing();
            _actions = new QueueActions(messageQueue.Consumer);

            _request = DataProviderRequestBuilder.ForLicensePlateSearch();
            _aggregateId = Guid.NewGuid();
        }

        public override void Observe()
        {
            var queue = new DataProviderQueueFunctions(_request, DataProviderCommandSource.RgtVin, _actions, _aggregateId);
            queue.TearDown()
                .Setup()
                .InitBus(BusBuilder.ForRgtVinCommands(_aggregateId))
                .InitStopWatch()
                .StartingDataProviderMessage()
                .ConfigurationMessage(new { VinNumber = "AHT31UNK408007735" })
                //.SecurityMessage()
                .StartCallingMessage()
                .FaultCallingMessage(new { NoRequestReceived = "No VINs were received" })
                .EndCallingMessage(DataProviderResponseBuilder.FromRgtVin())
                .TransformationMessage(DataProviderTransformationBuilder.ForRgtVin(),
                    new {TrasformationMetaData = "Transforming Response from Rgt Vin"})
                .EndingDataProvider();
        }

        [Observation]
        public void then_rgt_vin_messages_should_be_put_on_the_correct_write_queue()
        {
            var messageCount = _actions.GetMessageCount(ConfigureMonitoringWriteQueues.ForHost().ExchangeName,
                ConfigureMonitoringWriteQueues.ForHost().QueueName, ConfigureMonitoringWriteQueues.ForHost().RoutingKey,
                ConfigureMonitoringWriteQueues.ForHost().ExchangeType);
            messageCount.ShouldEqual(7);

        }
    }
}
