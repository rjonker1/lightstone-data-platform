using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.DataProviders;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Events
{
    public class when_publlishing_lace_ivid_monitoring_messages_to_bus : Specification
    {
        private ISendCommandsToBus _monitoring;
        private readonly ILaceRequest _request;
        private readonly HpiStandardQueryResponse _ividResponse;
        private readonly HpiStandardQueryRequest _ividRequest;
        private readonly DataProviderStopWatch _stopWatch;
        private readonly DataProviderStopWatch _dataProviderStopWatch;
        private Exception _exception;
        private readonly Guid _aggregateId;

        public when_publlishing_lace_ivid_monitoring_messages_to_bus()
        {
            _request = new LicensePlateNumberIvidOnlyRequest();
            _ividResponse = new SourceResponseBuilder().ForIvid();
            _ividRequest = DataProviderResponseBuilder.IvidHpiStandardQueryRequest(_request);
           

            _aggregateId = Guid.NewGuid();

            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProviderCommandSource.Ivid);
            _dataProviderStopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProviderCommandSource.Ivid);
        }

        public override void Observe()
        {
            try
            {
                _monitoring = BusBuilder.ForIvidCommands(_aggregateId);
            }
            catch (Exception e)
            {
                _exception = e;
            }
        }

        [Observation]
        public void lace_ivid_monitoring_data_provider_must_be_sent_to_message_queue()
        {
            _exception.ShouldBeNull();

            _monitoring.ShouldNotBeNull();

            _monitoring.Begin(_request,_dataProviderStopWatch);

            _monitoring.Send(CommandType.Configuration, _ividRequest,null);


            var proxy = DataProviderConfigurationBuilder.ForIvidWebServiceProxy();
            _monitoring.Send(CommandType.Security, new
            {
                Credentials =
                    new
                    {
                        proxy.ClientCredentials.UserName.UserName,
                        proxy.ClientCredentials.UserName.Password
                    }
            },
                    new { ContextMessage = "Ivid Data Provider Credentials" });


            _monitoring.StartCall(_ividRequest, _stopWatch);

            _monitoring.Send(CommandType.Fault, _request, new { NoRequestReceived = "No response received from Ivid Data Provider" });

            _monitoring.EndCall(_ividResponse ?? new HpiStandardQueryResponse(),_stopWatch);


            var transformer = DataProviderTransformationBuilder.ForIvid(_ividResponse);
            _monitoring.Send(CommandType.Transformation, transformer.Result, transformer);

            _monitoring.End(_request,_dataProviderStopWatch);
          
        }
    }
}

