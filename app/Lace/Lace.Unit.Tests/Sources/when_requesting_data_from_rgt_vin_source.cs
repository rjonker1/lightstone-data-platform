using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Fakes.Lace.SourceCalls;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources
{
    public class when_requesting_data_from_rgt_vin_source : Specification
    {
        private readonly IRequestDataFromDataProviderSource _requestDataFromService;
        private readonly ICollection<IPointToLaceRequest> _rgtVinRequest;
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly ISendMonitoringCommandsToBus _laceEvent;
        private readonly ICallTheDataProviderSource _externalWebServiceCall;

        public when_requesting_data_from_rgt_vin_source()
        {
            _requestDataFromService = new RequestDataFromIvidSource();
            _rgtVinRequest = new LicensePlateRequestBuilder().ForRgtVin();
            _response = new LaceResponseBuilder().WithIvidResponseHandled();
            _externalWebServiceCall = new FakeCallingRgtVinExternalWebService();
        }
        
        public override void Observe()
        {
            _requestDataFromService.FetchDataFromSource(_response, _externalWebServiceCall, _laceEvent);
        }


        [Observation]
        public void rgt_vin_request_data_from_service_response_must_not_be_null()
        {
            _response.OfType<IProvideDataFromRgtVin>().First().ShouldNotBeNull();
        }

        [Observation]
        public void rgt_vin_request_data_from_service_must_be_handled()
        {
            _response.OfType<IProvideDataFromRgtVin>().First().Handled.ShouldBeTrue();
        }


    }
}
