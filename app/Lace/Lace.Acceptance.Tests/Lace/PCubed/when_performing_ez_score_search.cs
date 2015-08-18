using System;
using System.Net;
using Lace.Toolbox.PCubed;
using Lace.Toolbox.PCubed.Domain;
using RestSharp;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_performing_ez_score_search : Specification
    {
        private readonly ConsumerViewService service;
        private IRestResponse<ConsumerViewResponse> response;

        public when_performing_ez_score_search()
        {
            service = new ConsumerViewService(new RestClient());
        }
        public override void Observe()
        {
            //var query = new ConsumerViewQuery { IdNumber = "4810100045085" }; // live example
            var query = new ConsumerViewQuery("4810100045085"); // live example
            response = service.Search(query);
        }

        [Observation]
        public void the_result_must_contain_the_individual_header_and_details()
        {
            response.StatusCode.ShouldEqual(HttpStatusCode.OK);
            response.ResponseStatus.ShouldEqual(ResponseStatus.Completed);

            var result = response.Data;
            result.Ticket.ShouldEqual(Guid.Empty);
            result.ErrorNumber.ShouldEqual(0);
            result.ErrorMessage.ShouldEqual(string.Empty);
            result.ResponseStatusCode.ShouldEqual(HttpStatusCode.OK);
            result.ResponseStatus.ShouldEqual("Success");
            result.DataFormat.ShouldEqual("Json");
            result.Compressed.ShouldEqual(false);

            result.IndividualData.ShouldNotBeNull();
            result.IndividualData.Individuals.ShouldNotBeNull();
            result.IndividualData.Individuals.Individual.ShouldNotBeEmpty();

            var person = result.IndividualData.Individuals.Individual[0];
            person.PCubed.ShouldNotBeNull();
            person.PCubed.Header.ShouldNotBeNull();
            person.PCubed.Header.IDNumber.ShouldEqual("4810100045085");
            person.PCubed.Header.FirstName.ShouldEqual("Peggy");
            person.PCubed.Header.Surname.ShouldEqual("Marais");
            person.PCubed.Header.Phone1.ShouldEqual("0831234567");
            person.PCubed.Header.Phone2.ShouldEqual("0217851930");
            person.PCubed.Header.Phone3.ShouldEqual("0217825600");
            person.PCubed.Header.EmailAddress1.ShouldEqual("");
            person.PCubed.Header.EmailAddress2.ShouldEqual("");
            person.PCubed.Header.EmailAddress3.ShouldEqual("");

            // TODO: LIVE TEST: This will change as they update data
            person.PCubed.Detail.ShouldNotBeNull();
            person.PCubed.Detail.AddressLine1.ShouldEqual("10 FOREST DRIVE");
            person.PCubed.Detail.AddressSuburb.ShouldEqual("SILVERGLADE");
            person.PCubed.Detail.AddressTownCity.ShouldEqual("FISH HOEK");
            person.PCubed.Detail.AddressProvince.ShouldEqual("WESTERN CAPE");
            person.PCubed.Detail.AddressPostCode.ShouldEqual("7975");
            person.PCubed.Detail.PostalAddressLine1.ShouldEqual("");
            person.PCubed.Detail.PostalAddressLine2.ShouldEqual("");
            person.PCubed.Detail.PostalAddressSuburb.ShouldEqual("");
            person.PCubed.Detail.PostalAddressTownCity.ShouldEqual("");
            person.PCubed.Detail.PostalAddressProvince.ShouldEqual("");
            person.PCubed.Detail.PostalAddressPostCode.ShouldEqual("");
            person.PCubed.Detail.DemAge.ShouldEqual(65);
            person.PCubed.Detail.DemGender.ShouldEqual("Female");
            person.PCubed.Detail.DemPredictedRace.ShouldEqual("White");
            person.PCubed.Detail.DemDeceased.ShouldEqual("Alive");
            person.PCubed.Detail.DemHomeOwner.ShouldEqual("R750K-R1M");
            person.PCubed.Detail.DemMaritalStatus.ShouldEqual(true);
            person.PCubed.Detail.DemDirector.ShouldEqual(false);
            person.PCubed.Detail.DemEntrepreneur.ShouldEqual(false);
            person.PCubed.Detail.DemDigitallyEnabled.ShouldEqual(false);

            person.PCubed.Detail.WealthIndex.ShouldEqual("R30K+");
            person.PCubed.Detail.CreditGradeNonCPA.ShouldEqual("Good");
            person.PCubed.Detail.CreditActiveNonCPA.ShouldEqual(true);
            person.PCubed.Detail.MosaicCPAGroupMerged.ShouldEqual("B8:Feet Up Wealth.People enjoying the fruits of their labour, often in later stages of their lives");
            person.PCubed.Detail.FASNonCPAGroupDescriptionShort.ShouldEqual("Premier Existence");
        }
    }
}
