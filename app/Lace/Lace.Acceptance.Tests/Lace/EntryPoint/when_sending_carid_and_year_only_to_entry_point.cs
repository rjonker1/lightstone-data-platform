using System.Collections.Generic;
using System.Linq;
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

namespace Lace.Acceptance.Tests.Lace.EntryPoint
{
    public class when_sending_carid_and_year_only_to_entry_point : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private ICollection<IPointToLaceProvider> _response;
        private readonly IAdvancedBus _command;
        private readonly IEntryPoint _entryPoint;

        public when_sending_carid_and_year_only_to_entry_point()
        {
            _command = BusFactory.WorkflowBus();
            _request = new CarIdRequestBuilder().ForAllCarIdSources();
            _entryPoint = new EntryPointService(_command);
        }

        public override void Observe()
        {
            _response = _entryPoint.GetResponsesForCarId(_request);
        }

        [Observation]
        public void lace_data_providers_accepting_car_id_should_have_responses()
        {
            _response.ShouldNotBeNull();
            _response.Count.ShouldEqual(3);
            _response.Count(c => c.Handled).ShouldEqual(3);

            _response.OfType<IProvideDataFromLightstoneAuto>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromLightstoneAuto>().First().Handled.ShouldBeTrue();
            _response.OfType<IProvideDataFromLightstoneAuto>().First().ResponseState.ShouldEqual(DataProviderResponseState.Successful);

            _response.OfType<IProvideDataFromRgt>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromRgt>().First().Handled.ShouldBeTrue();
            _response.OfType<IProvideDataFromRgt>().First().ResponseState.ShouldEqual(DataProviderResponseState.Successful);


            _response.OfType<IProvideDataFromMmCode>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromMmCode>().First().Handled.ShouldBeTrue();
            _response.OfType<IProvideDataFromMmCode>().First().ResponseState.ShouldEqual(DataProviderResponseState.Successful);

            _response.State().ShouldEqual(DataProviderResponseState.Successful);

        }
    }
}
