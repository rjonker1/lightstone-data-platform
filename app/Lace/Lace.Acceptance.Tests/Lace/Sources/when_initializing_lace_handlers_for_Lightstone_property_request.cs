using System;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Property;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Property;
using Lace.Test.Helper.Builders.Scans;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_Lightstone_property_request : Specification
    {
        private readonly ILaceRequest _request;
        private readonly IProvideResponseFromLaceDataProviders _response;
        private readonly ISendMonitoringCommandsToBus _monitoring;
        private readonly IExecuteTheDataProviderSource _dataProvider;


        //TODO: run tests
        public when_initializing_lace_handlers_for_Lightstone_property_request()
        {
            _monitoring = MonitoringBusBuilder.ForLightstonePropertyCommands(Guid.NewGuid());
            var lspRequestBuilder = new LspRequestBuilder();

            _request = lspRequestBuilder.ForReturnProperties();
            _response = new LaceResponse();
            _dataProvider = new LightstoneProperyDataProvider(_request, null, null, _monitoring);
        }

        public override void Observe()
        {
            _dataProvider.CallSource(_response);
        }

        [Observation]
        public void lace_lightstone_property_response_should_be_handled_test()
        {
            _response.LightstonePropertyResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_lightstone_property_response_shuould_not_be_null_test()
        {
            _response.LightstonePropertyResponse.ShouldNotBeNull();
        }

    }
}
