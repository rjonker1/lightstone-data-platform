using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataPlatform.Shared.Enums;
using EasyNetQ;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Extensions;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.EntryPointAsync
{
    public class when_sending_valid_vehicle_to_async_entry_point_service :Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private ICollection<IPointToLaceProvider> _response;
        private readonly IAdvancedBus _command;
        private readonly IEntryPointAsync _entryPoint;

        public when_sending_valid_vehicle_to_async_entry_point_service()
        {
            _command = BusFactory.WorkflowBus();
            _request = new LicensePlateRequestBuilder().ForAllSources().ToList();
            _entryPoint = new EntryPointAsyncService(_command);
        }

        public override void Observe()
        {
          
        }

        [Observation]
        public async void lace_data_providers_for_async_handled_loaded_correclty()
        {
            _response = await _entryPoint.GetResponsesAsync(_request);

            _response.ShouldNotBeNull();
            _response.Count.ShouldEqual(13);
            _response.Count(c => c.Handled).ShouldEqual(5);

            _response.HasAllRecords().ShouldBeTrue();
            _response.State().ShouldEqual(DataProviderResponseState.Successful);

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

            _response.OfType<IProvideDataFromVin12>().Any().ShouldBeFalse();

            _response.OfType<IProvideDataFromLightstoneProperty>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromLightstoneProperty>().First().Handled.ShouldBeFalse();
        }
    }
}
