using System;
using System.Threading;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using Monitoring.Queuing.Configuration;
using Monitoring.Queuing.Contracts;
using Monitoring.Queuing.RabbitMq;
using Monitoring.Test.Helper.Builder;
using Monitoring.Test.Helper.Messages;
using Monitoring.Test.Helper.Mothers;
using Xunit.Extensions;

namespace Monitoring.Acceptance.Tests.Queues
{
    public class when_sending_command_messages_to_the_queues_on_the_bus : Specification
    {
        private readonly ISendMonitoringMessages _monitoring;
        private readonly RabbitMqMessageQueueing _messageQueue;
        private readonly IHaveQueueActions _actions;
        private readonly string _request;

        private DataProviderStopWatch _stopWatch;
        private DataProviderStopWatch _dataProviderStopWatch;

        private readonly Guid _aggregateId;

        public when_sending_command_messages_to_the_queues_on_the_bus()
        {
            _messageQueue = new RabbitMqMessageQueueing();
            _actions = new QueueActions(_messageQueue.Consumer);

            _actions.DeleteAllQueues();
            _actions.DeleteAllExchanges();

            _actions.AddAllExchanges();
            _actions.AddAllQueues();


            _request = DataProviderRequestBuilder.ForIvid();

            _aggregateId = Guid.NewGuid();

            _monitoring = BusBuilder.ForMonitoringWriteMessages(_aggregateId);
        }


        public override void Observe()
        {
            PutMessagesOnQueue();
        }

        [Observation]
        public void then_messages_should_be_put_on_the_correct_write_queue()
        {
            var messageCount = _actions.GetMessageCount(ConfigureMonitoringWriteQueues.ForHost().ExchangeName,
                ConfigureMonitoringWriteQueues.ForHost().QueueName, ConfigureMonitoringWriteQueues.ForHost().RoutingKey,
                ConfigureMonitoringWriteQueues.ForHost().ExchangeType);
            messageCount.ShouldEqual(8);
        }

        //[Observation]
        //public void then_messages_should_be_put_on_the__correct_read_queue()
        //{
        //    var messageCount = _actions.GetMessageCount(ConfigureMonitoringReadQueues.ForHost().ExchangeName,
        //        ConfigureMonitoringReadQueues.ForHost().QueueName, ConfigureMonitoringReadQueues.ForHost().RoutingKey,
        //        ConfigureMonitoringReadQueues.ForHost().ExchangeType);
        //    messageCount.ShouldEqual(8);
        //}

        private void PutMessagesOnQueue()
        {
            _monitoring.ShouldNotBeNull();

            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProvider.Ivid);
            _dataProviderStopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProvider.Ivid);

            _monitoring.StartDataProvider(DataProvider.Ivid, _request, _dataProviderStopWatch);

            Thread.Sleep(1000);

            _monitoring.DataProviderConfiguration(DataProvider.Ivid, _request, string.Empty);

            Thread.Sleep(1000);

            var configJson = DataProviderConfigurationBuiler.ForIvid();
            _monitoring.DataProviderSecurity(DataProvider.Ivid, configJson,
                "Ivid Data Provider Credentials");

            _monitoring.StartCallingDataProvider(DataProvider.Ivid, _request, _stopWatch);

            Thread.Sleep(1000);

            _monitoring.DataProviderFault(DataProvider.Ivid, _request,
                "No response received from Ivid Data Provider");

            Thread.Sleep(1000);

            _monitoring.EndCallingDataProvider(DataProvider.Ivid, DataProviderResponseBuilder.FromIvid(),
                _stopWatch);

            Thread.Sleep(1000);
            //var transformer = DataProviderTransformationBuilder.ForIvid(_ividResponse);
            _monitoring.DataProviderTransformation(DataProvider.Ivid, DataProviderTransformationBuilder.ForIvid(),
                DataProviderResponseBuilder.FromIvid());

            Thread.Sleep(1000);

            _monitoring.EndDataProvider(DataProvider.Ivid, _request, _dataProviderStopWatch);

            Thread.Sleep(1000);
        }
    }
}
