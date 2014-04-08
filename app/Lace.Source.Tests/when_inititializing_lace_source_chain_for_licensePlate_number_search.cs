using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lace.Request;
using Lace.Source.Tests.Data;
using Xunit;
using Xunit.Extensions;

namespace Lace.Source.Tests
{
    public class when_inititializing_lace_source_chain_for_licensePlate_number_search : Specification
    {
        private readonly ILaceRequest _request;
        private readonly Initialize _initialize;
        private List<LaceResponse> _laceResponses;

        public when_inititializing_lace_source_chain_for_licensePlate_number_search()
        {
            _request = BuildRequest();
            _initialize = new Initialize();
        }

        private static ILaceRequest BuildRequest()
        {
            return new LicensePlateNumberSliverAllServicesRequest();
        }

        public override void Observe()
        {
            try
            {
                _laceResponses = _initialize
                    .Bootstrap(_request)
                    .Load()
                    .LaceResponses;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Observation]
        public void the_number_of_responses_to_be_received()
        {
            _laceResponses.First().Responses.Count().ShouldEqual(3);
        }

        [Observation]
        public void the_number_of_services_to_be_consumed()
        {
            _laceResponses.First().Responses.Count(c => c.Handled).ShouldEqual(3);
        }

        [Observation]
        public void the_number_of_services_to_be_handled()
        {
            foreach (var response in _laceResponses[0].Responses)
            {
                response.Handled.ShouldBeTrue();
            }
        }
    }

}
