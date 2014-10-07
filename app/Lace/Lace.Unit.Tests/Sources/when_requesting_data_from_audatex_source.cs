using Lace.DistributedServices.Events.Contracts;
using Lace.DistributedServices.Events.PublishMessageHandlers;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Audatex.Infrastructure;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Fakes.Bus;
using Lace.Test.Helper.Fakes.Lace.SourceCalls;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources
{
    public class when_requesting_data_from_audatex_source : Specification
    {
        private readonly IRequestDataFromDataProviderSource _requestDataFromSource;
        private readonly ILaceRequest _audatexRequest;
        private readonly IProvideResponseFromLaceDataProviders _laceResponse;
        private readonly ILaceEvent _laceEvent;
        private readonly ICallTheDataProviderSource _externalWebServiceCall;


        public when_requesting_data_from_audatex_source()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
            
            _requestDataFromSource = new RequestDataFromAudatexSource();
            _audatexRequest = new LicensePlateRequestBuilder().ForAudatex();
            _laceResponse = new LaceResponseBuilder().WithIvidResponseHandled();
            _externalWebServiceCall = new FakeCallingAudatexExternalWebService(_audatexRequest);

            _laceEvent = new PublishLaceEventMessages(publisher, _audatexRequest.RequestAggregation.AggregateId);
        }

        public override void Observe()
        {
            _requestDataFromSource.FetchDataFromSource(_laceResponse, _externalWebServiceCall, _laceEvent);
        }

        [Observation]
        public void lace_audatex_request_data_from_service_web_response_must_not_be_null()
        {
            _laceResponse.AudatexResponse.ShouldNotBeNull();
        }

        [Observation]
        public void lace_audatex_request_data_from_service_must_be_handled()
        {
            _laceResponse.AudatexResponseHandled.Handled.ShouldBeTrue();
        }
    }
}
