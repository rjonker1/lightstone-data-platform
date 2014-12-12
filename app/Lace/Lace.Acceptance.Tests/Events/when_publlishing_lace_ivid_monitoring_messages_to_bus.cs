using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Core;
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
        private ISendMonitoringMessages _monitoring;
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

            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProvider.Ivid);
            _dataProviderStopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProvider.Ivid);
        }

        public override void Observe()
        {
            try
            {
                _monitoring = BusBuilder.ForMonitoringMessages(_aggregateId);
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

            _monitoring.StartDataProvider(DataProvider.Ivid, _request.ObjectToJson(), _dataProviderStopWatch);

            _monitoring.DataProviderConfiguration(DataProvider.Ivid, _ividRequest.ObjectToJson(), string.Empty);

            var proxy = DataProviderConfigurationBuilder.ForIvidWebServiceProxy();
            _monitoring.DataProviderSecurity(DataProvider.Ivid, proxy.ObjectToJson(),
                "Ivid Data Provider Credentials");

            _monitoring.StartCallingDataProvider(DataProvider.Ivid, _ividRequest.ObjectToJson(), _stopWatch);

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

