using System;
using Lace.Source.IvidTitleHolder.IvidTitleHolderServiceReference;

namespace Lace.Source.Tests.Data.IvidTitleHolder
{
    public static class MockIvidTitleHolderQueryResponseData
    {
        public static TitleholderQueryResponse GetTitleHolderResponseForLicnseNumber()
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
