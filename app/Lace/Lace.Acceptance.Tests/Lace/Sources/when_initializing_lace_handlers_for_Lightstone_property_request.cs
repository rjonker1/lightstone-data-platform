using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Property;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Property;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_Lightstone_property_request : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly ISendMonitoringCommandsToBus _monitoring;
        private readonly IExecuteTheDataProviderSource _dataProvider;

        public when_initializing_lace_handlers_for_Lightstone_property_request()
        {
            _monitoring = MonitoringBusBuilder.ForLightstonePropertyCommands(Guid.NewGuid());
            var lspRequestBuilder = new LspRequestBuilder();

            _request = lspRequestBuilder.ForReturnProperties();
            _response = new Collection<IPointToLaceProvider>();
            _dataProvider = new LightstonePropertyDataProvider(_request, null, null, _monitoring);
        }

        public override void Observe()
        {
            _dataProvider.CallSource(_response);
        }

        [Observation]
        public void lace_lightstone_property_response_should_be_handled_test()
        {
            _response.OfType<IProvideDataFromLightstoneProperty>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_lightstone_property_response_shuould_not_be_null_test()
        {
            _response.OfType<IProvideDataFromLightstoneProperty>().First().ShouldNotBeNull();
        }

    }
}
