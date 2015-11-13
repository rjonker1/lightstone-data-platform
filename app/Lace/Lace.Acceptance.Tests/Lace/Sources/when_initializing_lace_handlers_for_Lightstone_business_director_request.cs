using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Business.Director;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_Lightstone_business_director_request : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly ISendCommandToBus _command;
        private readonly IExecuteTheDataProviderSource _dataProvider;

        public when_initializing_lace_handlers_for_Lightstone_business_director_request()
        {
            _command = MonitoringBusBuilder.ForLightstoneDirectorCommands(Guid.NewGuid());
            _request = new DirectorRequestBuilder().ForLightstoneDirector();
            _response = new Collection<IPointToLaceProvider>();
            _dataProvider = new LightstoneDirectorDataProvider(_request, null, null, _command);
        }

        public override void Observe()
        {
            _dataProvider.CallSource(_response);
        }

        [Observation]
        public void lace_lightstone_director_response_should_be_handled_test()
        {
            _response.OfType<IProvideDataFromLightstoneBusinessDirector>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_lightstone_director_response_shuould_not_be_null_test()
        {
            _response.OfType<IProvideDataFromLightstoneBusinessDirector>().First().ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_director_response_should_have_company()
        {
            _response.OfType<IProvideDataFromLightstoneBusinessDirector>().First().Directors.Count().ShouldEqual(1);
        }

        [Observation]
        public void lace_lightstone_director_response_should_have_property_buyers_name()
        {
            _response.OfType<IProvideDataFromLightstoneBusinessDirector>().First().Directors.First().CompanyRegNumber.ShouldEqual("2009/202656/23");
        }

    }
}