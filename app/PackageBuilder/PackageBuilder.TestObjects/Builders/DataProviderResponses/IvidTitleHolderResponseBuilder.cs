using System;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses
{
    public class IvidTitleHolderResponseBuilder
    {
        private IvidTitleHolderResponse _ividTitleHolderResponse = new IvidTitleHolderResponse();
        public IProvideDataFromIvidTitleHolder Build()
        {
            return _ividTitleHolderResponse;
        }

        public IvidTitleHolderResponseBuilder With(string bankName, bool flaggedOnAnpr, string accountNumber, DateTime accountOpenDate, DateTime accountCloseDate, string yearOfLiablilityForLicensing)
        {
            _ividTitleHolderResponse.Build(bankName, flaggedOnAnpr, accountNumber, accountOpenDate, accountCloseDate, yearOfLiablilityForLicensing);
            return this;
        }
    }
}