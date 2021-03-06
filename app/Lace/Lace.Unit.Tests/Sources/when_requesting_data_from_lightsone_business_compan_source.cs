﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Fakes.Lace.SourceCalls;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources
{
    public class when_requesting_data_from_lightsone_business_compan_source : Specification
    {
        private readonly IRequestDataFromDataProviderSource _requestDataFromService;
        private ICollection<IPointToLaceProvider> _response;
        private readonly ISendCommandToBus _command;
        private readonly ICallTheDataProviderSource _externalWebServiceCall;

        public when_requesting_data_from_lightsone_business_compan_source()
        {
            _command = MonitoringBusBuilder.ForLightstoneCompanyCommands(Guid.NewGuid());
            _requestDataFromService = new RequestDataFromLightstoneCompany();
            _response = new Collection<IPointToLaceProvider>();
            _externalWebServiceCall = new FakeCallingLightstoneBusinessCompanyExternalWebService();
        }

        public override void Observe()
        {
            _requestDataFromService.FetchDataFromSource(_response, _externalWebServiceCall);
        }

        [Observation]
        public void lace_lightstone_business_company_response_must_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneBusinessCompany>().First().ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_business_company_must_be_handled()
        {
            _response.OfType<IProvideDataFromLightstoneBusinessCompany>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_lightstone_business_company_must_have_valid_correct_company_name()
        {
            _response.OfType<IProvideDataFromLightstoneBusinessCompany>().First().Companies.First().CompanyName.ToUpper().ShouldEqual("LIGHTSTONE AUTO");
        }

        [Observation]
        public void lace_lightstone_business_company_must_have_valid_correct_physical_address()
        {
            _response.OfType<IProvideDataFromLightstoneBusinessCompany>().First().Companies.First().PhysicalAddress1.ToUpper().ShouldEqual("FERN GLEN FERNRIDGE OFFICE PARK");
        }
    }
}
