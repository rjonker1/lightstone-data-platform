using System.Collections.Generic;
using System.Linq;
using EasyNetQ;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Requests
{
    public class when_sending_company_request_to_lace_entry_point : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private ICollection<IPointToLaceProvider> _responses;
        private readonly IEntryPoint _entryPoint;
        private readonly IAdvancedBus _bus;

        public when_sending_company_request_to_lace_entry_point()
        {
            _bus = BusFactory.WorkflowBus();

            _request = new CompanyRequestBuilder().ForLightstoneCompany();
            _entryPoint = new EntryPointService(_bus);
        }

        public override void Observe()
        {
            _responses = _entryPoint.GetResponsesFromLace(_request);
        }

        [Observation]
        public void lace_request_to_be_loaded_and_responses_to_be_returned_for_company_search_sources()
        {
            _responses.ShouldNotBeNull();
            _responses.Count.ShouldEqual(8);
            _responses.Count(c => c.Handled).ShouldEqual(1);


            _responses.OfType<IProvideDataFromLightstoneBusinessCompany>().First().ShouldNotBeNull();
            _responses.OfType<IProvideDataFromLightstoneBusinessCompany>().First().Handled.ShouldBeTrue();
            _responses.OfType<IProvideDataFromLightstoneBusinessCompany>().First().Companies.ShouldNotBeNull();
            _responses.OfType<IProvideDataFromLightstoneBusinessCompany>().First().Companies.Count().ShouldEqual(1);

        }
    }
}
