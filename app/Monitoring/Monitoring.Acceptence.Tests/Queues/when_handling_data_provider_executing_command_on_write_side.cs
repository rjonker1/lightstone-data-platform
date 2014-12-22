using System;
using Autofac;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Commands;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Publisher;
using Lace.Shared.Monitoring.Messages.RabbitMQ;
using Lace.Shared.Monitoring.Messages.Shared;
using Monitoring.Queuing.Contracts;
using Monitoring.Queuing.RabbitMq;
using Monitoring.Test.Helper.Builder.DataProviderRequests;
using Monitoring.Test.Helper.Messages;
using Monitoring.Test.Helper.Mothers;
using Monitoring.Write.Service.DataProviders;
using Xunit.Extensions;

namespace Monitoring.Acceptance.Tests.Queues
{
    public class when_handling_data_provider_executing_command_on_write_side : Specification
    {
        private ISendMonitoringMessages _monitoring;
        private readonly RabbitMqMessageQueueing _messageQueue;
        private readonly IHaveQueueActions _setup;
        private readonly ILaceRequest _request;

        private DataProviderStopWatch _stopWatch;
        private DataProviderStopWatch _dataProviderStopWatch;

        private readonly Guid _aggregateId;

        public when_handling_data_provider_executing_command_on_write_side()
        {
            _messageQueue = new RabbitMqMessageQueueing();
            _setup = new QueueActions(_messageQueue.Consumer);
            _setup.DeleteAllQueues();
            _setup.AddAllQueues();


            _request = new DataProviderLicensePlateNumberRequest();

            _aggregateId = Guid.NewGuid();
        }


        public override void Observe()
        {
            _monitoring = BusBuilder.ForMonitoringMessages(_aggregateId);
        }

        [Observation]
        public void then_start_executing_ivid_data_provider_request_should_be_handled()
        {
            _monitoring.ShouldNotBeNull();

            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProvider.Ivid);
            _dataProviderStopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProvider.Ivid);

            _monitoring.StartDataProvider(DataProvider.Ivid, _request.ObjectToJson(), _dataProviderStopWatch);

            _monitoring.DataProviderConfiguration(DataProvider.Ivid, _request.ObjectToJson(), string.Empty);

            var proxy = DataProviderConfigurationBuilder.ForIvidWebServiceProxy();
            _monitoring.DataProviderSecurity(DataProvider.Ivid, proxy.ObjectToJson(),
                "Ivid Data Provider Credentials");

            _monitoring.StartCallingDataProvider(DataProvider.Ivid, _request.ObjectToJson(), _stopWatch);

            _monitoring.DataProviderFault(DataProvider.Ivid, _request.ObjectToJson(),
                "No response received from Ivid Data Provider");


            _monitoring.EndCallingDataProvider(DataProvider.Ivid,
                _ividResponse != null ? _ividResponse.ObjectToJson() : new HpiStandardQueryResponse().ObjectToJson(),
                _stopWatch);


            var transformer = DataProviderTransformationBuilder.ForIvid(_ividResponse);
            _monitoring.DataProviderTransformation(DataProvider.Ivid, transformer.Result.ObjectToJson(),
                transformer.ObjectToJson());

            _monitoring.EndDataProvider(DataProvider.Ivid, _request.ObjectToJson(), _dataProviderStopWatch);
        }
    }
}
