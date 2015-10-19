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
    public class when_getting_meta_data_for_vehicle_search : Specification
    {
        private IEntryPoint _entryPoint;

        private readonly ICollection<IPointToLaceRequest> _request;
        private ICollection<IPointToLaceProvider> _response;
        //private readonly IAdvancedBus _bus;

        public when_getting_meta_data_for_vehicle_search()
        {
            //_bus = BusFactory.WorkflowBus();
            _entryPoint = new MetadataEntryPointService();
            _request = new LicensePlateRequestBuilder().ForAllSources();

        }
        public override void Observe()
        {
           _response = _entryPoint.GetResponses(_request);
        }

        [Observation]
        public void lace_source_in_chain_to_be_loaded_correctly()
        {
            _response.ShouldNotBeNull();
            _response.Count.ShouldEqual(9);
            _response.Count(c => c.Handled).ShouldEqual(5);

            _response.OfType<IProvideDataFromIvid>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromIvid>().First().Handled.ShouldBeTrue();

            _response.OfType<IProvideDataFromIvidTitleHolder>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromIvidTitleHolder>().First().Handled.ShouldBeTrue();

            _response.OfType<IProvideDataFromRgtVin>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromRgtVin>().First().Handled.ShouldBeTrue();

            _response.OfType<IProvideDataFromRgt>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromRgt>().First().Handled.ShouldBeTrue();

            _response.OfType<IProvideDataFromLightstoneAuto>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromLightstoneAuto>().First().Handled.ShouldBeTrue();
        }
    }
}
