using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Audatex.AudatexServiceReference;
using Lace.Domain.DataProviders.Audatex.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Audatex.Infrastructure.Dto;
using Lace.Domain.DataProviders.Audatex.Infrastructure.Management;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Events
{
    public class when_publlishing_lace_audatex_monitoring_commands_to_bus : Specification
    {
        private ISendCommandsToBus _monitoring;
        private readonly ILaceRequest _request;
        private readonly IProvideResponseFromLaceDataProviders _audatexResponse;
        private readonly AudatexRequest _audatexRequest;
        private readonly DataProviderStopWatch _stopWatch;
        private readonly DataProviderStopWatch _dataProviderStopWatch;
        private Exception _exception;
        private readonly Guid _aggregateId;
        private GetDataResult _result;

        public when_publlishing_lace_audatex_monitoring_commands_to_bus()
        {
            _request = new LicensePlateNumberAudatexOnlyRequest();
            _audatexResponse = new SourceResponseBuilder().ForAudatexWithLaceResponse();
            _audatexRequest = new ConfigureAudatexRequestMessage(_audatexResponse)
                    .Build()
                    .AudatexRequest;
           

            _aggregateId = Guid.NewGuid();

            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProviderCommandSource.Ivid);
            _dataProviderStopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProviderCommandSource.Ivid);
        }

        public override void Observe()
        {
            _monitoring = BusBuilder.ForAudatexCommands(_aggregateId);
        }

        [Observation]
        public void lace_audatex_monitoring_data_provider_must_be_sent_to_message_queue()
        {
            _monitoring.ShouldNotBeNull();

            _monitoring.Begin(_request, _dataProviderStopWatch);

            _monitoring.Send(CommandType.Configuration, _audatexRequest, null);


            //var proxy = DataProviderConfigurationBuilder.ForIvidWebServiceProxy();
            //_monitoring.Send(CommandType.Security, new
            //{
            //    Credentials =
            //        new
            //        {
            //            proxy.ClientCredentials.UserName.UserName,
            //            proxy.ClientCredentials.UserName.Password
            //        }
            //},
            //    new {ContextMessage = "Ivid Data Provider Credentials"});


            _monitoring.StartCall(_audatexRequest, _stopWatch);

            _monitoring.Send(CommandType.Fault, _request,
                new { NoRequestReceived = "No response received from Audatex Data Provider" });

            _result = new SourceResponseBuilder().ForAudatexWithHuyandaiHistory();

            _monitoring.EndCall(_result ?? new GetDataResult(), _stopWatch);


            var transformer = new TransformAudatexResponse(_result, _audatexResponse, _request);
            _monitoring.Send(CommandType.Transformation, transformer.Result, transformer);

            _monitoring.End(_request, _dataProviderStopWatch);

        }
    }
}

