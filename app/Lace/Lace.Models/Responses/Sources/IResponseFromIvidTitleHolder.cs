using System;
namespace Lace.Models.Responses.Sources
{
    public interface IResponseFromIvidTitleHolder : IPointToLaceSource
    {
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
