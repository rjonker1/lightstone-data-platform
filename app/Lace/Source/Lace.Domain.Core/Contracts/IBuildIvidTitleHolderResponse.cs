using System;

namespace Lace.Domain.Core.Contracts
{
    public interface IBuildIvidTitleHolderResponse
    {
        void Build(string bankName, bool flaggedOnAnpr, string accountNumber, DateTime accountOpenDate,
            DateTime accountCloseDate, string yearOfLiablilityForLicensing);

        void IsPartial(bool check);
        void HasErrorsCheck(bool check);

        void SetRequestFinancialInterestInvite();

    }
}
