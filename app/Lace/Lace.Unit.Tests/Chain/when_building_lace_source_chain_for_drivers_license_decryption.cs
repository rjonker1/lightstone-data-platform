﻿using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Test.Helper.Builders.Scans;
using Lace.Test.Helper.Fakes.Lace;
using Lace.Test.Helper.Fakes.Lace.Builder;
using NServiceBus;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Chain
{
    public class when_building_lace_source_chain_for_drivers_license_decryption : Specification
    {
        private IBootstrap _initialize;

        private readonly ILaceRequest _request;
        private readonly IBus _bus;
        private Dictionary<Type, Func<ILaceRequest, IProvideResponseFromLaceDataProviders>> _handlers;
        private readonly IBuildSourceChain _buildSourceChain;

        public when_building_lace_source_chain_for_drivers_license_decryption()
        {
            _bus = Lace.Test.Helper.Builders.Buses.BusFactory.NServiceRabbitMqBus();
            _request = new DriversLicenseRequestBuilder().ForDriversLicenseScan();
            _buildSourceChain = new FakeSourceChain(_request.Package.Action);
            _buildSourceChain.Build();
        }

        public override void Observe()
        {
            _initialize = new FakeLaceInitializer(new LaceResponse(), _request, _bus, _buildSourceChain);
            _initialize.Execute();
        }

        [Observation]
        public void then_drivers_license_source_chain_should_be_loaded_correctly()
        {
            _initialize.LaceResponses.Count.ShouldEqual(1);
            _initialize.LaceResponses[0].Response.ShouldNotBeNull();

            _initialize.LaceResponses[0].Response.SignioDriversLicenseDecryptionResponse.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.SignioDriversLicenseDecryptionResponseHandled.Handled.ShouldBeTrue();
        }
    }
}