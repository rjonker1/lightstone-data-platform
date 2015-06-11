using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EasyNetQ;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Lace;
using Lace.Test.Helper.Fakes.Lace.Builder;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Chain
{
    public class when_building_lace_source_chain_for_company_search : Specification
    {
        private IBootstrap _initialize;

        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly IAdvancedBus _bus;
        private readonly IBuildSourceChain _buildSourceChain;

        public when_building_lace_source_chain_for_company_search()
        {
            _bus = BusFactory.WorkflowBus();
            _request = new CompanyRequestBuilder().ForLightstoneCompany();
            _buildSourceChain = new FakeSourceChain();
        }

        public override void Observe()
        {
            _initialize = new FakeLaceInitializer(new Collection<IPointToLaceProvider>(), _request, _bus, _buildSourceChain);
            _initialize.Execute();
        }

        [Observation]
        public void lace_chain_for_company_search_should_be_loaded_correctly()
        {
            _initialize.ShouldNotBeNull();
            _initialize.DataProviderResponses.Count(c => c.Handled).ShouldEqual(1);

            _initialize.DataProviderResponses.OfType<IProvideDataFromLightstoneBusinessCompany>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromLightstoneBusinessCompany>().First().Handled.ShouldBeTrue();
            _initialize.DataProviderResponses.OfType<IProvideDataFromLightstoneBusinessCompany>().First().Companies.ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromLightstoneBusinessCompany>().First().Companies.Count().ShouldEqual(1);
        }
    }
}
