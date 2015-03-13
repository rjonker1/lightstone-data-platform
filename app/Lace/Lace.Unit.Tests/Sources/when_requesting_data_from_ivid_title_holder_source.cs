
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Fakes.Lace.SourceCalls;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources
{
    public class when_requesting_data_from_ivid_title_holder_source : Specification
    {
        private readonly IRequestDataFromDataProviderSource _requestDataFromService;
        private readonly ILaceRequest _ividTitleHolderRequest;
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly ISendMonitoringCommandsToBus _laceEvent;
        private readonly ICallTheDataProviderSource _externalWebServiceCall;

        public when_requesting_data_from_ivid_title_holder_source()
        {

            _requestDataFromService = new RequestDatafromIvidTitleHolderSource();
            _ividTitleHolderRequest = new LicensePlateRequestBuilder().ForIvidTitleHolder();
            _response = new LaceResponseBuilder().WithIvidResponseHandled();
            _externalWebServiceCall = new FakeCallingIvidTitleHolderExternalWebService();
        }

        public override void Observe()
        {
            _requestDataFromService.FetchDataFromSource(_response, _externalWebServiceCall, _laceEvent);
        }

        [Observation]
        public void ivid_title_holder_request_data_from_service_response_must_not_be_nul()
        {
            _response.OfType<IProvideDataFromIvidTitleHolder>().First().ShouldNotBeNull();
        }

        [Observation]
        public void ivid_title_holder_request_data_from_service_must_be_handled()
        {
            _response.OfType<IProvideDataFromIvidTitleHolder>().First().Handled.ShouldBeTrue();
        }
    }
}
