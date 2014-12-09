using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Audatex.Infrastructure;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Fakes.Lace.SourceCalls;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources
{
    public class when_requesting_data_from_audatex_source : Specification
    {
        private readonly IRequestDataFromDataProviderSource _requestDataFromSource;
        private readonly ILaceRequest _audatexRequest;
        private readonly IProvideResponseFromLaceDataProviders _laceResponse;
        private readonly ISendMonitoringMessages _monitoring;
        private readonly ICallTheDataProviderSource _externalWebServiceCall;


        public when_requesting_data_from_audatex_source()
        {
            //var bus = new FakeBus();
            //var publisher = new Workflow.RabbitMQ.Publisher(bus);
            
            _requestDataFromSource = new RequestDataFromAudatexSource();
            _audatexRequest = new LicensePlateRequestBuilder().ForAudatex();
            _laceResponse = new LaceResponseBuilder().WithIvidResponseHandled();
            _externalWebServiceCall = new FakeCallingAudatexExternalWebService(_audatexRequest);

            //_monitoring = new PublishLaceEventMessages(publisher, _audatexRequest.RequestAggregation.AggregateId);
        }

        public override void Observe()
        {
            _requestDataFromSource.FetchDataFromSource(_laceResponse, _externalWebServiceCall, _monitoring);
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
