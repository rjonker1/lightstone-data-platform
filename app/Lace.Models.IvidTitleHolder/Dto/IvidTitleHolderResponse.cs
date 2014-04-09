using System;
using Lace.Models.Enums;

namespace Lace.Models.IvidTitleHolder.Dto
{
    public class IvidTitleHolderResponse
    {
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public DateTime? DateOpened { get; set; }

      
        public string FinancialInterestsHeading { get; set; }
        public string AccountOpenDate { get; set; }
        public string AccountClosedDate { get; set; }
        public string AgreementType { get; set; }
        public string YearOfLiabilityForLicensing { get; set; }
        public string RequestFinancialInterestInvite { get; set; }
        public bool FinancialInterestAvailable { get; set; }

     
        public bool PartialResponse { get; set; }
        public bool HasErrors { get; set; }
        public ServiceCallState ServiceProviderCallState { get; set; }
        public string ExpiredMessage { get; set; }
    }
}
