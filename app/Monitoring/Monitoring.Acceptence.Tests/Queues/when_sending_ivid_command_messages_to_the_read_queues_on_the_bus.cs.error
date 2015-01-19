using System;
using System.Threading;
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
    public class when_sending_ivid_command_messages_to_the_read_queues_on_the_bus : Specification
    {
        private readonly object _request;

        private readonly Guid _aggregateId;
        private readonly IHaveQueueActions _actions;

        public when_sending_ivid_command_messages_to_the_read_queues_on_the_bus()
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
                .InitReadBus()
                .InitStopWatch()
                .DataProviderExecutingEvent()
                .DataProviderHasConfigurationEvent()
                .DataProviderHasSecurityEvent()
                .DataProviderIsCalledEvent()
                .DataProviderHasFaultEvent()
                .DataProviderCallEndedEvent()
                .DataProviderasBeenTransformedEvent()
                .DataProviderHasExecutedEvent();
        }

        [Observation]
        public void then_ivid_messages_should_be_put_on_the_correct_read_queue()
        {
            var messageCount = _actions.GetMessageCount(ConfigureMonitoringReadQueues.ForHost().ExchangeName,
                ConfigureMonitoringReadQueues.ForHost().QueueName, ConfigureMonitoringReadQueues.ForHost().RoutingKey,
                ConfigureMonitoringReadQueues.ForHost().ExchangeType);
            messageCount.ShouldEqual(8);

        }
    }
}
