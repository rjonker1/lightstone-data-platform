using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneBusinessCompany;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.LightstoneAuto
{
    public class PCubedEzScoreMother
    {
        public static IRespondWithEzScore EzScore
        {
            get
            {
                return new PCubedEzScoreBuilder()
                    .WithHeader("Phone1", "Phone2", "Phone3", "EmailAddress1", "EmailAddress2", "EmailAddress3",
                        "Surname", "FirstName", "IdNumber")
                    .WithDetail("DemLsm", "FasNonCpaGroupDescriptionShort", "MosaicCpaGroupMerged", "WealthIndex",
                        "true", "DemHomeOwner", "Deceased", "DemPredictedRace", "DemGender",
                        "PostalAddressPostCode", "PostalAddressProvince", "PostalAddressTownCity", "PostalAddressSuburb",
                        "PostalAddressLine2", "PostalAddressLine1", "AddressPostCode", "AddressProvince",
                        "AddressTownCity", "AddressSuburb", "AddressLine2", "AddressLine1", "ExtractDate")
                    .Build();
            }
        }
    }
}