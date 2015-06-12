using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Fakes.Lace.SourceCalls;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources
{
    public class when_requesting_data_from_lightsone_business_director_source : Specification
    {
        private readonly IRequestDataFromDataProviderSource _requestDataFromService;
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly ISendCommandToBus _command;
        private readonly ICallTheDataProviderSource _externalWebServiceCall;

        public when_requesting_data_from_lightsone_business_director_source()
        {
            _command = MonitoringBusBuilder.ForLightstoneDirectorCommands(Guid.NewGuid());
            _requestDataFromService = new RequestDataFromLightstoneDirector();
            _response = new Collection<IPointToLaceProvider>();
            _externalWebServiceCall = new FakeCallingLightstoneBusinessDirectorExternalWebService();
        }

        public override void Observe()
        {
            _requestDataFromService.FetchDataFromSource(_response, _externalWebServiceCall);
        }

        [Observation]
        public void lace_lightstone_director_company_response_must_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneBusinessDirector>().First().ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_director_company_must_be_handled()
        {
            _response.OfType<IProvideDataFromLightstoneBusinessDirector>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_lightstone_director_company_must_have_valid_correct_director_name()
        {
            _response.OfType<IProvideDataFromLightstoneBusinessDirector>().First().Directors.First().CompanyRegNumber.ShouldEqual("2009/202656/23");
        }

        [Observation]
        public void lace_lightstone_director_company_must_have_valid_correct_residential_address()
        {
            _response.OfType<IProvideDataFromLightstoneBusinessDirector>().First().Directors.First().ResidentialAddress1.ToUpper().ShouldEqual("48 BELLAIRS VIEW");
        }
    }
}
