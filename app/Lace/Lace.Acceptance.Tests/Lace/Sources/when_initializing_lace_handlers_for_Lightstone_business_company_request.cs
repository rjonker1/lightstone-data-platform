using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Business.Company;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_Lightstone_business_company_request : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly ISendCommandToBus _command;
        private readonly IExecuteTheDataProviderSource _dataProvider;

        public when_initializing_lace_handlers_for_Lightstone_business_company_request()
        {
            _command = MonitoringBusBuilder.ForLightstoneCompanyCommands(Guid.NewGuid());
            _request = new CompanyRequestBuilder().ForLightstoneCompany();
            _response = new Collection<IPointToLaceProvider>();
            _dataProvider = new LightstoneCompanyDataProvider(_request, null, null, _command);
        }

        public override void Observe()
        {
            _dataProvider.CallSource(_response);
        }

        [Observation]
        public void lace_lightstone_company_response_should_be_handled_test()
        {
            _response.OfType<IProvideDataFromLightstoneBusinessCompany>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_lightstone_company_response_shuould_not_be_null_test()
        {
            _response.OfType<IProvideDataFromLightstoneBusinessCompany>().First().ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_compan_response_should_have_company()
        {
            _response.OfType<IProvideDataFromLightstoneBusinessCompany>().First().Companies.Count().ShouldEqual(1);
        }

        [Observation]
        public void lace_lightstone_property_response_should_have_property_buyers_name()
        {
            _response.OfType<IProvideDataFromLightstoneBusinessCompany>().First().Companies.First().CompanyName.ShouldEqual("LIGHTSTONE AUTO");
        }

    }
}