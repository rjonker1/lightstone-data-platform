using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EasyNetQ;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Shared.Extensions;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_ivid_request : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly IAdvancedBus _command;
        private readonly IBootstrap _initialize;
        private ICollection<IPointToLaceProvider> _response;
        private readonly IBuildSourceChain _buildSourceChain;

        public when_initializing_lace_handlers_for_ivid_request()
        {
            _command = BusFactory.WorkflowBus();
            _request = new LicensePlateRequestBuilder().ForIvid();
            _buildSourceChain = new SpecificationFactory();
            //_buildSourceChain = new CreateSourceChain(_request.GetFromRequest<IPointToLaceRequest>().Package);
            //_buildSourceChain.Build();
            _initialize = new Initialize(new Collection<IPointToLaceProvider>(),  _request, _command, _buildSourceChain);
        }


        public override void Observe()
        {
            _initialize.Execute(ChainType.All);
            _response = _initialize.DataProviderResponses;
        }

        [Observation]
        public void lace_response_to_be_returned_should_be_13()
        {
            _response.Count.ShouldEqual(14);
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

        [Observation]
        public void lave_ivid_response_request_should_have_valid_license_plate_response()
        {
            _response.OfType<IProvideDataFromIvid>().First().License.ShouldEqual("CL49CTGP");
        }
    }
}
