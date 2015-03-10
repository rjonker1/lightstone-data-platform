using System;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_lightstone : Specification
    {
        private readonly ILaceRequest _request;
        private readonly IProvideResponseFromLaceDataProviders _response;
        private readonly ISendMonitoringCommandsToBus _monitoring;
        private readonly IExecuteTheDataProviderSource _dataProvider;

        public when_initializing_lace_handlers_for_lightstone()
        {
            _monitoring = MonitoringBusBuilder.ForLightstoneCommands(Guid.NewGuid());
            _request = new LicensePlateRequestBuilder().ForLightstone();
            _response = new LaceResponseBuilder().WithIvidResponseHandled();
            _dataProvider = new LightstoneDataProvider(_request, null, null, _monitoring);
        }

        public override void Observe()
        {
            _dataProvider.CallSource(_response);
        }

        [Observation]
        public void lace_rgt_response_should_be_handled()
        {
            _response.LightstoneResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_rgt_response_should_not_be_null()
        {
            _response.LightstoneResponse.ShouldNotBeNull();
        }
    }
}
