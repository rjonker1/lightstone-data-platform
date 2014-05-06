using System;
using Lace.Models.Enums;

namespace Lace.Models.IvidTitleHolder.Dto
{
    public class IvidTitleHolderResponse : IResponseFromIvidTitleHolder
    {
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public DateTime? DateOpened { get; set; }

        public bool FlaggedOnAnpr { get; set; }

        public string FinancialInterestsHeading
        {
            get { return "Financial Interests"; }
        }

        public string AccountOpenDate { get; set; }
        public string AccountClosedDate { get; set; }

        public string AgreementType
        {
            get { return "Regular Finance Contract"; }
        }

        public string YearOfLiabilityForLicensing { get; set; }

        public string RequestFinancialInterestInvite
        {
            get
            {

                return GetFinancialInterestInvite();
            }
        }

        public bool FinancialInterestAvailable
        {
            get
            {
                return GetFinancialInterestAvailable();
            }
        }


        public bool PartialResponse { get; set; }
        public bool HasErrors { get; set; }
        public ServiceCallState ServiceProviderCallState { get; set; }

        public string ExpiredMessage
        {
            get
            {
                return
                    "This report is older than 15 days, we recommend you generate a new one as information may have changed since then";
            }
        }

        private string GetFinancialInterestInvite()
        {
            if (RequiredFieldsAreNotValid())
                return "No financial interest exists for this vehicle";


            return "wesbank".Equals(BankName, StringComparison.InvariantCultureIgnoreCase)
                ? "To request financial interest please click on the 'Request' button"
                : "Financed Interest is only available for WesBank customers at this point in time";
        }

        private bool GetFinancialInterestAvailable()
        {
            return RequiredFieldsAreNotValid()
                ? false
                : "wesbank".Equals(BankName, StringComparison.InvariantCultureIgnoreCase);
        }

        private bool RequiredFieldsAreNotValid()
        {
            return string.IsNullOrEmpty(AccountNumber) && !ValidateDateValue(AccountOpenDate) &&
                   !ValidateDateValue(AccountClosedDate);
        }

        private static bool ValidateDateValue(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            DateTime validDate;
            return (DateTime.TryParse(value, out validDate));
        }
    }
}
