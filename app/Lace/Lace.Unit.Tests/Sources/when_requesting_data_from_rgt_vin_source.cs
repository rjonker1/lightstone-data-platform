using Lace.Domain.Core.Contracts;
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
        private readonly ILaceRequest _rgtVinRequest;
        private IProvideResponseFromLaceDataProviders _laceResponse;
        private readonly ISendCommandsToBus _laceEvent;
        private readonly ICallTheDataProviderSource _externalWebServiceCall;

        public when_requesting_data_from_rgt_vin_source()
        {
            //var bus = new FakeBus();
            //var publisher = new Workflow.RabbitMQ.Publisher(bus);
            
            _requestDataFromService = new RequestDataFromIvidSource();
            _rgtVinRequest = new LicensePlateRequestBuilder().ForRgtVin();
            _laceResponse = new LaceResponseBuilder().WithIvidResponseHandled();
            _externalWebServiceCall = new FakeCallingRgtVinExternalWebService();
            //_laceEvent = new PublishLaceEventMessages(publisher, _rgtVinRequest.RequestAggregation.AggregateId);
        }
        
        public override void Observe()
        {
            _requestDataFromService.FetchDataFromSource(_laceResponse, _externalWebServiceCall, _laceEvent);
        }


        [Observation]
        public void rgt_vin_request_data_from_service_response_must_not_be_null()
        {
            _laceResponse.RgtVinResponse.ShouldNotBeNull();
        }

        [Observation]
        public void rgt_vin_request_data_from_service_must_be_handled()
        {
            _laceResponse.RgtVinResponseHandled.Handled.ShouldBeTrue();
        }


    }
}
