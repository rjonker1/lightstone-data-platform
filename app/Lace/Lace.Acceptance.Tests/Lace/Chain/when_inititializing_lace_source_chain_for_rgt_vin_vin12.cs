using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DataPlatform.Shared.Enums;
using EasyNetQ;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Extensions;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Shared.Extensions;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Chain
{
    public class when_inititializing_lace_source_chain_for_rgt_vin_vin12 : Specification
    {
        private IBootstrap _initialize;

        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly IAdvancedBus _command;
        private Dictionary<Type, Func<IPointToLaceRequest, IProvideResponseFromLaceDataProviders>> _handlers;

        private readonly IBuildSourceChain _buildSourceChain;

        public when_inititializing_lace_source_chain_for_rgt_vin_vin12()
        {

            _command = BusFactory.WorkflowBus();
            _request = new VinRequestBuilder().ForRgtVin12VinNumber();
            _buildSourceChain = new SpecificationFactory();
        }

        public override void Observe()
        {
            _initialize = new Initialize(new Collection<IPointToLaceProvider>(), _request, _command, _buildSourceChain);
            _initialize.Execute(ChainType.All);
        }

        [Observation]
        public void lace_data_providers_for_must_be_handled_loaded_correclty()
        {
            _initialize.DataProviderResponses.ShouldNotBeNull();
            _initialize.DataProviderResponses.Count.ShouldEqual(15);
            _initialize.DataProviderResponses.Count(c => c.Handled).ShouldEqual(2);

            _initialize.DataProviderResponses.OfType<IProvideDataFromIvid>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromIvid>().First().Handled.ShouldBeFalse();

            _initialize.DataProviderResponses.OfType<IProvideDataFromIvidTitleHolder>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromIvidTitleHolder>().First().Handled.ShouldBeFalse();

            _initialize.DataProviderResponses.OfType<IProvideDataFromRgtVin>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromRgtVin>().First().Handled.ShouldBeTrue();
            _initialize.DataProviderResponses.OfType<IProvideDataFromRgtVin>().First().ResponseState.ShouldEqual(DataProviderResponseState.NoRecords);

            _initialize.DataProviderResponses.OfType<IProvideDataFromRgt>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromRgt>().First().Handled.ShouldBeFalse();

            _initialize.DataProviderResponses.OfType<IProvideDataFromLightstoneAuto>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromLightstoneAuto>().First().Handled.ShouldBeFalse();

            _initialize.DataProviderResponses.OfType<IProvideDataFromLightstoneProperty>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromLightstoneProperty>().First().Handled.ShouldBeFalse();

            _initialize.DataProviderResponses.OfType<IProvideDataFromVin12>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromVin12>().First().Handled.ShouldBeTrue();
            _initialize.DataProviderResponses.OfType<IProvideDataFromVin12>().First().ResponseState.ShouldEqual(DataProviderResponseState.VinShort);
            _initialize.DataProviderResponses.OfType<IProvideDataFromVin12>().First().Vin12Information.Count().ShouldEqual(24);

            _initialize.DataProviderResponses.HasAllRecords().ShouldBeFalse();
            _initialize.DataProviderResponses.State().ShouldEqual(DataProviderResponseState.VinShort);
        }
    }
}