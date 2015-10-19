using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Metadata.Entrypoint;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Metadata
{
    public class when_getting_meta_data_for_company_search : Specification
    {
        private IEntryPoint _entryPoint;

        private readonly ICollection<IPointToLaceRequest> _request;
        private ICollection<IPointToLaceProvider> _response;
        //private readonly IAdvancedBus _bus;

        public when_getting_meta_data_for_company_search()
        {
            //_bus = BusFactory.WorkflowBus();
            _entryPoint = new MetadataEntryPointService();
            _request = new CompanyRequestBuilder().ForLightstoneCompany();

        }
        public override void Observe()
        {
           _response = _entryPoint.GetResponses(_request);
        }

        [Observation]
        public void lace_meta_data_source_for_company_search_in_chain_to_be_loaded_correctly()
        {
            _response.ShouldNotBeNull();
            _response.Count.ShouldEqual(9);
            _response.Count(c => c.Handled).ShouldEqual(1);

            _response.OfType<IProvideDataFromLightstoneBusinessCompany>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromLightstoneBusinessCompany>().First().Handled.ShouldBeTrue();
            _response.OfType<IProvideDataFromLightstoneBusinessCompany>().First().Companies.ShouldNotBeNull();
            _response.OfType<IProvideDataFromLightstoneBusinessCompany>().First().Companies.Count().ShouldEqual(1);
        }
    }
}
