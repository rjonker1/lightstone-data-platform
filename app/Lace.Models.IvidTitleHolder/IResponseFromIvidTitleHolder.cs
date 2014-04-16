using System;
using Lace.Models.Enums;

namespace Lace.Models.IvidTitleHolder
{
    public interface IResponseFromIvidTitleHolder
    {
         string BankName { get; set; }
         string AccountNumber { get; set; }
         DateTime? DateOpened { get; set; }


         string FinancialInterestsHeading { get; set; }
         string AccountOpenDate { get; set; }
         string AccountClosedDate { get; set; }
         string AgreementType { get; set; }
         string YearOfLiabilityForLicensing { get; set; }
         string RequestFinancialInterestInvite { get; set; }
         bool FinancialInterestAvailable { get; set; }


         bool PartialResponse { get; set; }
         bool HasErrors { get; set; }
         ServiceCallState ServiceProviderCallState { get; set; }
         string ExpiredMessage { get; set; }
    }
}
