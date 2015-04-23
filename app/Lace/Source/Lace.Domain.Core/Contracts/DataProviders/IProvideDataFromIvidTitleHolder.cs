using System;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Core.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromIvidTitleHolder : IPointToLaceProvider
    {
        IAmIvidTitleholderRequest Request { get; }
        string BankName { get; }
        string AccountNumber { get; }
        DateTime? DateOpened { get; }

        string FinancialInterestsHeading { get; }

        string AccountOpenDate { get; }
        string AccountClosedDate { get; }
        string AgreementType { get; }
        string YearOfLiabilityForLicensing { get; }
        string RequestFinancialInterestInvite { get; }
        bool FinancialInterestAvailable { get; }

        bool PartialResponse { get; }
        bool HasErrors { get; }
        string ExpiredMessage { get; }
    }
}
