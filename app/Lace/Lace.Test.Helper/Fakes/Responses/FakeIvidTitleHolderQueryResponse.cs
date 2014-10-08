using System;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;

namespace Lace.Test.Helper.Fakes.Responses
{
    public static class FakeIvidTitleHolderQueryResponseData
    {
        public static TitleholderQueryResponse GetTitleHolderResponseForLicenseNumber()
        {
            return new TitleholderQueryResponse()
            {
                accountClosedDate = DateTime.Now.AddYears(-5),
                accountNumber = "00009009838",
                accountClosedDateSpecified = true,
                accountOpenDate = DateTime.Now.AddYears(-10),
                accountOpenDateSpecified = true,
                bankName = "WesBank",
                engineNumber = null,
                flaggedOnAnpr = false,
                make = "Toyota",
                model = "Hilux",
                partialResponse = false,
                vin = "AHT31UNK408007735",
                yearOfLiabilityForLicensing = null
            };
        }
    }
}
