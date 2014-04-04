using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lace.Request;
using Xunit;
using Xunit.Extensions;

namespace Lace.Source.Tests
{
    public class when_init_lace_sources_for_licensePlate_number_search : Specification
    {
        private readonly ILaceRequest _request;
        private readonly Initialize _initialize;
        private List<LaceResponse> _laceResponses;

        public when_init_lace_sources_for_licensePlate_number_search()
        {
            _request = BuildRequest();
            _initialize = new Initialize();
        }

        private static ILaceRequest BuildRequest()
        {
            return new Request();
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
        public void TheNumberOfResponsesToBeReceived()
        {
            _laceResponses.First().Responses.Count().ShouldEqual(3);
        }

         [Observation]
        public void TheNumberOfServicesToBeConsumed()
        {
            _laceResponses.First().Responses.Count(c => c.Handled).ShouldEqual(3);
        }

        [Observation]
        public void TheNumberOfServicesToBeHandled()
        {
            foreach (var response in _laceResponses[0].Responses)
            {
                response.Handled.ShouldBeTrue();
            }
        }
    }

    public class Request : ILaceRequest
    {

        public Guid UserId
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        public string CompanyId
        {
            get
            {
                return string.Empty;
            }
        }

        public string ContractId
        {
            get
            {
                return string.Empty;
            }
        }

        public DateTime RequestDate
        {
            get
            {
                return DateTime.Now;
            }
        }

        public string LicensePlateNumber
        {
            get
            {
                return "XMC167GP";
            }
        }

        public string[] Sources
        {
            get
            {
                return new string[] {"Ivid", "IvidTitleHolder", "RgtVin"};
            }
        }
    }

}
