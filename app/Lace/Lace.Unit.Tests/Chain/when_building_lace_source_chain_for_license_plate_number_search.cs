﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EasyNetQ;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Shared.Extensions;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Lace;
using Lace.Test.Helper.Fakes.Lace.Builder;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Chain
{
    public class when_building_lace_source_chain_for_license_plate_number_search : Specification
    {

        private IBootstrap _initialize;

        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly IAdvancedBus _bus;
        private Dictionary<Type, Func<IPointToLaceRequest, IProvideResponseFromLaceDataProviders>> _handlers;

        private readonly IBuildSourceChain _buildSourceChain;

        public when_building_lace_source_chain_for_license_plate_number_search()
        {
            _bus = BusFactory.WorkflowBus();
            _request = new LicensePlateRequestBuilder().ForAllSources();
            _buildSourceChain = new FakeSourceChain();
        }

        public override void Observe()
        {
            _initialize = new FakeLaceInitializer(new Collection<IPointToLaceProvider>(), _request, _bus, _buildSourceChain);
            _initialize.Execute(ChainType.All);
        }


        [Observation]
        public void lace_source_in_chain_to_be_loaded_correctly()
        {

            _initialize.ShouldNotBeNull();
            _initialize.DataProviderResponses.Count.ShouldEqual(8);
            _initialize.DataProviderResponses.Count(c => c.Handled).ShouldEqual(5);

            _initialize.DataProviderResponses.OfType<IProvideDataFromIvid>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromIvid>().First().Handled.ShouldBeTrue();

            _initialize.DataProviderResponses.OfType<IProvideDataFromIvidTitleHolder>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromIvidTitleHolder>().First().Handled.ShouldBeTrue();

            _initialize.DataProviderResponses.OfType<IProvideDataFromRgtVin>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromRgtVin>().First().Handled.ShouldBeTrue();

            _initialize.DataProviderResponses.OfType<IProvideDataFromRgt>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromRgt>().First().Handled.ShouldBeTrue();

            _initialize.DataProviderResponses.OfType<IProvideDataFromLightstoneAuto>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromLightstoneAuto>().First().Handled.ShouldBeTrue();

            _initialize.DataProviderResponses.OfType<IProvideDataFromSignioDriversLicenseDecryption>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromSignioDriversLicenseDecryption>().First().Handled.ShouldBeFalse();

            //_initialize.DataProviderResponses.OfType<IProvideDataFromAudatex>().First().ShouldNotBeNull();
            //_initialize.DataProviderResponses.OfType<IProvideDataFromAudatex>().First().Handled.ShouldBeTrue();

        }

    }
}
