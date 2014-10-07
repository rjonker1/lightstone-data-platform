using Lace.DistributedServices.Events.Contracts;
using Lace.DistributedServices.Events.PublishMessageHandlers;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Bus;
using Lace.Test.Helper.Fakes.Lace.SourceCalls;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources
{
    public class when_requesting_data_from_ivid_source : Specification
    {
        private readonly IRequestDataFromDataProviderSource _requestDataFromService;
        private readonly ILaceRequest _ividRequest;
        private IProvideResponseFromLaceDataProviders _laceResponse;
        private readonly ILaceEvent _laceEvent;
        private readonly ICallTheDataProviderSource _externalWebServiceCall;

        public when_requesting_data_from_ivid_source()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
           
            _requestDataFromService = new RequestDataFromIvidSource();
            _ividRequest = new LicensePlateRequestBuilder().ForIvid();
            _laceResponse = new LaceResponse();
            _externalWebServiceCall = new FakeCallingIvidExternalWebService();
            _laceEvent = new PublishLaceEventMessages(publisher, _ividRequest.RequestAggregation.AggregateId);
        }
        
        public override void Observe()
        {
            _requestDataFromService.FetchDataFromSource(_laceResponse, _externalWebServiceCall, _laceEvent);
        }

        [Observation]
        public void lace_ivid_request_data_from_service_response_must_not_be_null()
        {
            _laceResponse.IvidResponse.ShouldNotBeNull();
        }

        [Observation]
        public void lace_ivid_request_data_from_service_must_be_handled()
        {
            _laceResponse.IvidResponseHandled.Handled.ShouldBeTrue();
        }


    }
}
