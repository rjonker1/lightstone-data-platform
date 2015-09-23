using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EasyNetQ;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Chain
{
    public class when_inititializing_lace_source_chain_for_vin_rgt_mm_code_search :Specification
    {
        private IBootstrap _initialize;

        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly IAdvancedBus _command;
        private Dictionary<Type, Func<IPointToLaceRequest, IProvideResponseFromLaceDataProviders>> _handlers;

        private readonly IBuildSourceChain _buildSourceChain;

        public when_inititializing_lace_source_chain_for_vin_rgt_mm_code_search()
        {

            _command = BusFactory.WorkflowBus();
            _request = new LicensePlateMmCodeRequestBuilder().ForIvidRgtVinMmCode();
            _buildSourceChain = new CreateSourceChain();
        }

        public override void Observe()
        {
            _initialize = new Initialize(new Collection<IPointToLaceProvider>(), _request, _command, _buildSourceChain);
            _initialize.Execute();
        }

        [Observation]
        public void lace_data_providers_for_must_be_handled_loaded_correclty()
        {
            _initialize.DataProviderResponses.ShouldNotBeNull();
            _initialize.DataProviderResponses.Count.ShouldEqual(13);
            _initialize.DataProviderResponses.Count(c => c.Handled).ShouldEqual(3);

            _initialize.DataProviderResponses.OfType<IProvideDataFromIvid>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromIvid>().First().Handled.ShouldBeTrue();

            _initialize.DataProviderResponses.OfType<IProvideDataFromIvidTitleHolder>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromIvidTitleHolder>().First().Handled.ShouldBeFalse();

            _initialize.DataProviderResponses.OfType<IProvideDataFromRgtVin>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromRgtVin>().First().Handled.ShouldBeTrue();

            _initialize.DataProviderResponses.OfType<IProvideDataFromRgt>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromRgt>().First().Handled.ShouldBeFalse();

            _initialize.DataProviderResponses.OfType<IProvideDataFromLightstoneAuto>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromLightstoneAuto>().First().Handled.ShouldBeFalse();

            _initialize.DataProviderResponses.OfType<IProvideDataFromLightstoneProperty>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromLightstoneProperty>().First().Handled.ShouldBeFalse();

            _initialize.DataProviderResponses.OfType<IProvideDataFromMmCode>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromMmCode>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_data_providers_must_have_same_car_id()
        {
            _initialize.DataProviderResponses.OfType<IProvideDataFromIvid>().First().CarFullname.ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromMmCode>()
                .First()
                .CarId.ShouldEqual(_initialize.DataProviderResponses.OfType<IProvideDataFromRgtVin>().First().CarId);

        }
    }
}
