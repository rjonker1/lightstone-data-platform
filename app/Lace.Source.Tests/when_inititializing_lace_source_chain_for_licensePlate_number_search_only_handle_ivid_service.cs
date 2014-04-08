using System.Collections.Generic;
using System.Linq;
using Lace.Request;
using Lace.Source.Tests.Data;
using Xunit.Extensions;

namespace Lace.Source.Tests
{
    public class when_inititializing_lace_source_chain_for_licensePlate_number_search_only_handle_ivid_service :
        Specification
    {

        private readonly ILaceRequest _request;
        private readonly Initialize _initialize;
        private List<LaceResponse> _laceResponses;

        public when_inititializing_lace_source_chain_for_licensePlate_number_search_only_handle_ivid_service()
        {
            _request = new LicensePlateNumberSliverIvidOnlyServiceRequest();
            _initialize = new Initialize();
        }

        public override void Observe()
        {
            _laceResponses = _initialize
                   .Bootstrap(_request)
                   .Load()
                   .LaceResponses;
        }

        [Observation]
        public void the_number_of_responses_to_be_received_should_be_still_be_three()
        {
            _laceResponses.First().Responses.Count().ShouldEqual(3);
        }

        [Observation]
        public void the_number_of_services_to_be_consumed_should_be_one()
        {
            _laceResponses.First().Responses.Count(c => c.Handled).ShouldEqual(1);
        }
    }

}
