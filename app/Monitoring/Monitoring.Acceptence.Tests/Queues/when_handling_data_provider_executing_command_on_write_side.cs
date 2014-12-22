using System;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using Monitoring.Queuing.Contracts;
using Monitoring.Queuing.RabbitMq;
using Monitoring.Test.Helper.Builder;
using Monitoring.Test.Helper.Messages;
using Monitoring.Test.Helper.Mothers;
using Xunit.Extensions;

namespace Monitoring.Acceptance.Tests.Queues
{
    public class when_handling_data_provider_executing_command_on_write_side : Specification
    {
        private ISendMonitoringMessages _monitoring;
        private readonly RabbitMqMessageQueueing _messageQueue;
        private readonly IHaveQueueActions _setup;
        private readonly string _request;

        private DataProviderStopWatch _stopWatch;
        private DataProviderStopWatch _dataProviderStopWatch;

        private readonly Guid _aggregateId;

        public when_handling_data_provider_executing_command_on_write_side()
        {
            _messageQueue = new RabbitMqMessageQueueing();
            _setup = new QueueActions(_messageQueue.Consumer);
            _setup.DeleteAllQueues();
            _setup.AddAllQueues();


            _request = DataProviderRequestBuilder.ForIvid();

            _aggregateId = Guid.NewGuid();
        }


        public override void Observe()
        {
            _monitoring = BusBuilder.ForMonitoringMessages(_aggregateId);
        }

        [Observation]
        public void then_monitoring_from_ivid_data_provider_should_be_handled()
        {
            _monitoring.ShouldNotBeNull();

            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProvider.Ivid);
            _dataProviderStopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProvider.Ivid);

            _monitoring.StartDataProvider(DataProvider.Ivid, _request, _dataProviderStopWatch);

            _monitoring.DataProviderConfiguration(DataProvider.Ivid, _request, string.Empty);

            var configJson = DataProviderConfigurationBuiler.ForIvid();
            _monitoring.DataProviderSecurity(DataProvider.Ivid, configJson,
                "Ivid Data Provider Credentials");

            _monitoring.StartCallingDataProvider(DataProvider.Ivid, _request, _stopWatch);

            _monitoring.DataProviderFault(DataProvider.Ivid, _request,
                "No response received from Ivid Data Provider");


            _monitoring.EndCallingDataProvider(DataProvider.Ivid, DataProviderResponseBuilder.FromIvid(),
                _stopWatch);


            //var transformer = DataProviderTransformationBuilder.ForIvid(_ividResponse);
            _monitoring.DataProviderTransformation(DataProvider.Ivid, DataProviderTransformationBuilder.ForIvid(),
                DataProviderResponseBuilder.FromIvid());

            _monitoring.EndDataProvider(DataProvider.Ivid, _request, _dataProviderStopWatch);
        }
    }
}
