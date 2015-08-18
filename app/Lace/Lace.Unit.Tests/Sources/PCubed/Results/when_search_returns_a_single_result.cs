using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Lace.Toolbox.PCubed;
using Lace.Toolbox.PCubed.Deserialization;
using Lace.Toolbox.PCubed.Domain;
using Moq;
using RestSharp;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.PCubed.Results
{
    public class when_search_returns_a_single_result : Specification
    {

        private readonly ConsumerViewService service;
        private readonly Mock<RestClient> client;
        private IRestResponse<ConsumerViewResponse> response;

        public when_search_returns_a_single_result()
        {
            //var deserializer = new PCubedJsonDeserializer();
            //var json = FileHelper.Read(GetType(), "Results");

            //client = new Mock<RestClient>();
            //client
            //    .Setup(c => c.BaseUrl)
            //    .Returns(new ConfigurationProvider().BaseUrl);
            //client
            //    .Setup(c => c.Execute<ConsumerViewResponse>(It.IsAny<IRestRequest>()))
            //    .Returns(new RestResponse<ConsumerViewResponse>
            //    {
            //        Data = deserializer.Deserialize<ConsumerViewResponse>(new RestResponse { Content = json }),
            //        StatusCode = HttpStatusCode.OK,
            //        ResponseStatus = ResponseStatus.Completed
            //    });

            //service = new ConsumerViewService(client.Object);
        }

        public override void Observe()
        {
            var query = new ConsumerViewQuery { IdNumber = "4810100045085" }; // example query
            response = service.Search(query);
        }

        [Observation(Skip="Need to implement")]
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

            person.PCubed.Detail.ShouldNotBeNull();
            person.PCubed.Detail.ExtractDate.ShouldEqual("2013/07/09");
            person.PCubed.Detail.AddressLine1.ShouldEqual("10 FOREST DRIVE");
            person.PCubed.Detail.AddressLine2.ShouldEqual("SILVERGLADE");
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
            person.PCubed.Detail.DemAge.ShouldEqual(64);
            person.PCubed.Detail.DemGender.ShouldEqual("Female");
            person.PCubed.Detail.DemPredictedRace.ShouldEqual("White");
            person.PCubed.Detail.DemDeceased.ShouldEqual("Alive");
            person.PCubed.Detail.DemHomeOwner.ShouldEqual("R750K-R1M");
            person.PCubed.Detail.DemMaritalStatus.ShouldEqual(true);
            person.PCubed.Detail.DemDirector.ShouldEqual(false);
            person.PCubed.Detail.DemEntrepreneur.ShouldEqual(false);
            person.PCubed.Detail.DemDigitallyEnabled.ShouldEqual(false);
            person.PCubed.Detail.WealthIndex.ShouldEqual("R30K+");
            person.PCubed.Detail.CreditGradeNonCPA.ShouldEqual("No History");
            person.PCubed.Detail.CreditActiveNonCPA.ShouldEqual(false);
            person.PCubed.Detail.MosaicCPAGroupMerged.ShouldEqual("");
            person.PCubed.Detail.DemLSM.ShouldEqual("LSM9L-9H");
            person.PCubed.Detail.FASNonCPAGroupDescriptionShort.ShouldEqual("Very High");
        }
    

}

    }
}
