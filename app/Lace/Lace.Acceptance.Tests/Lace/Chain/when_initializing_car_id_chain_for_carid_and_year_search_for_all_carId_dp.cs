using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DataPlatform.Shared.Enums;
using EasyNetQ;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Extensions;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Chain
{
    public class when_initializing_car_id_chain_for_carid_and_year_search_for_all_carId_dp : Specification
    {
        private IBootstrap _initialize;
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly IAdvancedBus _command;
        private readonly IBuildSourceChain _buildSourceChain;

        public when_initializing_car_id_chain_for_carid_and_year_search_for_all_carId_dp()
        {
            _command = BusFactory.WorkflowBus();
            _request = new CarIdRequestBuilder().ForAllCarIdSources();
            _buildSourceChain = new CreateSourceChain();
        }

        public override void Observe()
        {
            _initialize = new Initialize(new Collection<IPointToLaceProvider>(), _request, _command, _buildSourceChain);
            _initialize.Execute(ChainType.CarId);
        }

        [Observation]
        public void lace_data_providers_accepting_car_id_should_have_responses()
        {
            _initialize.DataProviderResponses.ShouldNotBeNull();
            _initialize.DataProviderResponses.Count.ShouldEqual(3);
            _initialize.DataProviderResponses.Count(c => c.Handled).ShouldEqual(3);

            _initialize.DataProviderResponses.OfType<IProvideDataFromLightstoneAuto>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromLightstoneAuto>().First().Handled.ShouldBeTrue();
            _initialize.DataProviderResponses.OfType<IProvideDataFromLightstoneAuto>().First().ResponseState.ShouldEqual(DataProviderResponseState.Successful);

            _initialize.DataProviderResponses.OfType<IProvideDataFromRgt>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromRgt>().First().Handled.ShouldBeTrue();
            _initialize.DataProviderResponses.OfType<IProvideDataFromRgt>().First().ResponseState.ShouldEqual(DataProviderResponseState.Successful);


            _initialize.DataProviderResponses.OfType<IProvideDataFromMmCode>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromMmCode>().First().Handled.ShouldBeTrue();
            _initialize.DataProviderResponses.OfType<IProvideDataFromMmCode>().First().ResponseState.ShouldEqual(DataProviderResponseState.Successful);

            _initialize.DataProviderResponses.State().ShouldEqual(DataProviderResponseState.Successful);

        }
    }
}
