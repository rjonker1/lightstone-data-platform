
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Fakes.Bus;
using Lace.Test.Helper.Fakes.Lace.SourceCalls;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources
{
    public class when_requesting_data_from_ivid_title_holder_source : Specification
    {
        private readonly IRequestDataFromDataProviderSource _requestDataFromService;
        private readonly ILaceRequest _ividTitleHolderRequest;
        private IProvideResponseFromLaceDataProviders _laceResponse;
        private readonly ISendMonitoringMessages _laceEvent;
        private readonly ICallTheDataProviderSource _externalWebServiceCall;

        public when_requesting_data_from_ivid_title_holder_source()
        {
            //var bus = new FakeBus();
            //var publisher = new Workflow.RabbitMQ.Publisher(bus);


            _requestDataFromService = new RequestDatafromIvidTitleHolderSource();
            _ividTitleHolderRequest = new LicensePlateRequestBuilder().ForIvidTitleHolder();
            _laceResponse = new LaceResponseBuilder().WithIvidResponseHandled();
            _externalWebServiceCall = new FakeCallingIvidTitleHolderExternalWebService();
            //_laceEvent = new PublishLaceEventMessages(publisher, _ividTitleHolderRequest.RequestAggregation.AggregateId);


        }

        public override void Observe()
        {
            _requestDataFromService.FetchDataFromSource(_laceResponse, _externalWebServiceCall, _laceEvent);
        }

        [Observation]
        public void ivid_title_holder_request_data_from_service_response_must_not_be_nul()
        {
            _laceResponse.IvidTitleHolderResponse.ShouldNotBeNull();
        }

        [Observation]
        public void ivid_title_holder_request_data_from_service_must_be_handled()
        {
            _laceResponse.IvidTitleHolderResponseHandled.Handled.ShouldBeTrue();
        }


    }
}
