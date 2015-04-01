﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Shared.Extensions;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using NServiceBus;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_ivid_request : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly IBus _monitoring;
        private readonly IBootstrap _initialize;
        private ICollection<IPointToLaceProvider> _response;
        private readonly IBuildSourceChain _buildSourceChain;

        public when_initializing_lace_handlers_for_ivid_request()
        {
            _monitoring = BusFactory.MonitoringBus();
            _request = new LicensePlateRequestBuilder().ForIvid();
            _buildSourceChain = new CreateSourceChain(_request.GetFromRequest<IAmVehicleRequest>().Package);
            _buildSourceChain.Build();
            _initialize = new Initialize(new Collection<IPointToLaceProvider>(),  _request, _monitoring, _buildSourceChain);
        }


        public override void Observe()
        {
            _initialize.Execute();
            _response = _initialize.DataProviderResponses;
        }

        [Observation]
        public void lace_response_to_be_returned_should_be_one()
        {
            _response.Count.ShouldEqual(6);
        }

        [Observation]
        public void lace_ivid_response_should_be_handled()
        {
            _response.OfType<IProvideDataFromIvid>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_ivid_response_shuould_not_be_null()
        {
            _response.OfType<IProvideDataFromIvid>().First().ShouldNotBeNull();
        }
    }
}
