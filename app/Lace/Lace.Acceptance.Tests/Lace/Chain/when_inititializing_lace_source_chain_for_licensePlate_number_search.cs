﻿using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using NServiceBus;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Chain
{
    public class when_inititializing_lace_source_chain_for_licensePlate_number_search : Specification
    {
        private IBootstrap _initialize;

        private readonly ILaceRequest _request;
        private readonly IBus _monitoring;
        private Dictionary<Type, Func<ILaceRequest, IProvideResponseFromLaceDataProviders>> _handlers;

        private readonly IBuildSourceChain _buildSourceChain;

        public when_inititializing_lace_source_chain_for_licensePlate_number_search()
        {

            _monitoring = BusFactory.MonitoringBus();
            _request = new LicensePlateRequestBuilder().ForAllSources();
            _buildSourceChain = new CreateSourceChain(_request.Package);
            _buildSourceChain.Build();
        }

        public override void Observe()
        {
            _initialize = new Initialize(new LaceResponse(), _request, _monitoring, _buildSourceChain);
            _initialize.Execute();
        }

        [Observation]
        public void lace_data_providers_for_VVI_product_must_be_handled_loaded_correclty()
        {
            _initialize.LaceResponses.Count.ShouldEqual(1);
            _initialize.LaceResponses[0].Response.ShouldNotBeNull();

            _initialize.LaceResponses[0].Response.IvidResponse.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.IvidResponseHandled.Handled.ShouldBeTrue();

            _initialize.LaceResponses[0].Response.IvidTitleHolderResponse.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.IvidTitleHolderResponseHandled.Handled.ShouldBeTrue();

            _initialize.LaceResponses[0].Response.RgtVinResponse.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.RgtVinResponseHandled.Handled.ShouldBeTrue();

            //_initialize.LaceResponses[0].Response.RgtResponse.ShouldNotBeNull();
            //_initialize.LaceResponses[0].Response.RgtResponseHandled.Handled.ShouldBeTrue();

            _initialize.LaceResponses[0].Response.LightstoneResponse.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.LightstoneResponseHandled.Handled.ShouldBeTrue();

            _initialize.LaceResponses[0].Response.AudatexResponse.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.AudatexResponseHandled.Handled.ShouldBeTrue();

        }
    }
}
