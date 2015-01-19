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
    public class when_sending_ivid_title_holder_command_messages_to_the_write_queue_on_the_bus : Specification
    {

        private readonly object _request;

        private readonly Guid _aggregateId;
        private readonly IHaveQueueActions _actions;


        public when_sending_ivid_title_holder_command_messages_to_the_write_queue_on_the_bus()
        {
            var messageQueue = new RabbitMqMessageQueueing();
            _actions = new QueueActions(messageQueue.Consumer);

            _request = DataProviderRequestBuilder.ForLicensePlateSearch();
            _aggregateId = Guid.NewGuid();
        }

        public override void Observe()
        {
            var queue = new DataProviderQueueFunctions(_request, DataProviderCommandSource.IvidTitleHolder, _actions,
                _aggregateId);
            queue.TearDown()
                .Setup()
                .InitBus(BusBuilder.ForIvidTitleHolderCommands(_aggregateId))
                .InitStopWatch()
                .StartingDataProviderMessage()
                .ConfigurationMessage(DataProviderConfigurationBuiler.ForIvidTitleHolder())
                .SecurityMessage(new
                {
                    Credentials =
                        new
                        {
                            UserName = "CARSTATS-CARSTATS",
                            Password = "8B5Jk3Q66"
                        }
                },
                    new {ContextMessage = "Ivid Title Holder Data Provider Credentials"})
                .StartCallingMessage()
                .FaultCallingMessage(
                    new {NoRequestReceived = "No response received from Ivid Title Holder Data Provider"})
                .EndCallingMessage(DataProviderResponseBuilder.FromIvidTitleHolder())
                .TransformationMessage(DataProviderTransformationBuilder.ForIvidTitleHolder(),
                    new {TrasformationMetaData = "Transforming Response from Ivid Title Holder"})
                .EndingDataProvider();
        }

        [Observation]
        public void then_ivid_title_holder_messages_should_be_put_on_the_correct_queue()
        {
            var messageCount = _actions.GetMessageCount(ConfigureMonitoringWriteQueues.ForHost().ExchangeName,
                ConfigureMonitoringWriteQueues.ForHost().QueueName, ConfigureMonitoringWriteQueues.ForHost().RoutingKey,
                ConfigureMonitoringWriteQueues.ForHost().ExchangeType);
            messageCount.ShouldEqual(8);
        }
    }
}
