using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_ivid_title_holder_source_with_financed_interest : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ISendMonitoringMessages _laceEvent;
        private readonly IProvideResponseFromLaceDataProviders _response;
        private IvidTitleHolderDataProvider _consumer;


        public when_consuming_ivid_title_holder_source_with_financed_interest()
        {
            //var bus = new FakeBus();
            //var publisher = new Workflow.RabbitMQ.Publisher(bus);

            _request = new LicensePlateNumberIvidTitleHolderWithAbsaFinancedInterestRequest();
            _response = new LaceResponseBuilder().WithIvidResponseAndFinancedInterestVin();

            //_laceEvent = new PublishLaceEventMessages(publisher, _request.RequestAggregation.AggregateId);
        }

        public override void Observe()
        {
            _consumer = new IvidTitleHolderDataProvider(_request, null, null);
            _consumer.CallSource(_response, _laceEvent);
        }


        [Observation]
        public void ivid_title_holder_consumer_with_financed_interest_must_be_handled()
        {
            _response.IvidTitleHolderResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void ivid_title_holder_response_from_consumer_with_financed_interest_must_not_be_null()
        {
            _response.IvidTitleHolderResponse.ShouldNotBeNull();
        }

        [Observation]
        public void ivid_title_holder_consumer_with_financed_interest_next_source_must_be_null()
        {
            _consumer.Next.ShouldBeNull();
        }

        [Observation]
        public void ivid_title_holder_consumer_with_financed_interest_fallback_source_must_be_null()
        {
            _consumer.FallBack.ShouldBeNull();
        }

        [Observation]
        public void ivid_title_holder_consumer_with_financed_interest_should_be_available()
        {
            _response.IvidTitleHolderResponse.FinancialInterestAvailable.ShouldBeTrue();
        }
    }
}
