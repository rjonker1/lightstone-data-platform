using System;
using System.Collections.Generic;
using System.Net;
using Lace.Toolbox.PCubed.Domain;
using RestSharp;

namespace Lace.Test.Helper.Fakes.Responses
{
    public class FakePcubedEzScoreResponse
    {
        public static RestResponse<ConsumerViewResponse> SuccessfulConsumerViewResponse()
        {
            var response = new ConsumerViewResponse(
                Guid.NewGuid(),
                Guid.NewGuid(),
                0,
                "",
                HttpStatusCode.OK,
                "Success",
                "LSNonCPAAuto",
                "LightStoneNonCPA",
                "Json", false, "00:00:00.0003832", DateTime.Now, IndividualData());

            return new RestResponse<ConsumerViewResponse>()
            {
                Data = response
            };
        }

        private static IndividualData IndividualData()
        {
            return new IndividualData()
            {
                Individuals = Individuals()
            };
        }

        private static Individuals Individuals()
        {
            return new Individuals()
            {
                Individual = new List<Individual>()
                {
                    new Individual()
                    {
                        PCubed = new PCubed()
                        {
                            Header = new Header()
                            {
                                FirstName = "Peggy",
                                Phone1 = "0839890057",
                                Phone2 = "0831234567",
                                Phone3 = "0217851930",
                                Surname = "Marais",
                                IDNumber = "4810100045085",
                                EmailAddress1 = "",
                                EmailAddress2 = "",
                                EmailAddress3 = ""

                            },
                            Detail = new Detail()
                            {
                                AddressLine1 = "3 SUIKERBEKKIE STR",
                                AddressLine2 = "",
                                AddressPostCode = "7220",
                                AddressProvince = "",
                                AddressSuburb = "",
                                AddressTownCity = "",
                                CreditActiveNonCPA = true,
                                CreditGradeNonCPA = "Good",
                                DemAge = 66,
                                DemDeceased = "Alive",
                                DemDigitallyEnabled = false,
                                DemDirector = false,
                                DemEntrepreneur = false,
                                DemGender = "Female",
                                DemHomeOwner = "R750K-R1M",
                                DemMaritalStatus = true,
                                DemPredictedRace = "White",
                                ExtractDate = "2015/07/18",
                                FASNonCPAGroupDescriptionShort = "Premier Existence",
                                MosaicCPAGroupMerged =
                                    "B7:Feet Up Wealth.People enjoying the fruits of their labour, often in later stages of their lives",
                                PostalAddressLine1 = "P O BOX 1390",
                                PostalAddressLine2 = "",
                                PostalAddressPostCode = "7220",
                                PostalAddressProvince = "WESTERN CAPE",
                                PostalAddressSuburb = "",
                                PostalAddressTownCity = "",
                                WealthIndex = "R30K+"
                            }
                        }
                    }
                }
            };
        }
    }
}
