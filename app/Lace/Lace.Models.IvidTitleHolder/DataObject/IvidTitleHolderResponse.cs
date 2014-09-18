using System;
using Lace.Models.Responses.Sources;

namespace Lace.Models.IvidTitleHolder.DataObject
{
    public class IvidTitleHolderResponse : IProvideDataFromIvidTitleHolder, IBuildIvidTitleHolderResponse
    {
        private const string NotAvailableError = "Error - Not Available";

        public void Build(string bankName, bool flaggedOnAnpr, string accountNumber, DateTime accountOpenDate, DateTime accountCloseDate, string yearOfLiablilityForLicensing)
        {
            BankName = CheckPartial(bankName);
            FlaggedOnAnpr = flaggedOnAnpr;
            AccountNumber = CheckPartial(accountNumber);
            AccountOpenDate = FormatDate(accountOpenDate);
            AccountClosedDate = FormatDate(accountCloseDate);
            YearOfLiabilityForLicensing = CheckPartial(yearOfLiablilityForLicensing);
        }


        public void IsPartial(bool check)
        {
            PartialResponse |= check;
        }

        public void HasErrorsCheck(bool check)
        {
            HasErrors |= check;
        }

        private string CheckPartial(string value)
        {
            if (HasErrors && string.IsNullOrWhiteSpace(value))
            {
                value = NotAvailableError;
            }
            return value;
        }

        private static string FormatDate(DateTime? date)
        {
            if (!date.HasValue || date.Value == DateTime.MinValue) return NotAvailableError;

            return date.Value.ToString("dd MMMM yyyy");
        }

        public void SetRequestFinancialInterestInvite()
        {
            var validation =
                new FinancedInterestValidation(string.IsNullOrEmpty(BankName)
                    ? string.Empty
                    : BankName.ToLowerInvariant(),!string.IsNullOrEmpty(AccountNumber));

            validation.Check();

            FinancialInterestAvailable = validation.FinancedInterestIsAvailable;
            RequestFinancialInterestInvite = validation.FinancialInterestInvite;

        }


        public string BankName { get; private set; }
        public string AccountNumber { get; private set; }
        public DateTime? DateOpened { get;  private set; }

        public bool FlaggedOnAnpr { get; private set; }

        public string FinancialInterestsHeading
        {
            get { return "Financial Interests"; }
        }

        public string AccountOpenDate { get; private set; }
        public string AccountClosedDate { get; private set; }

        public string AgreementType
        {
            get { return "Regular Finance Contract"; }
        }

        public string YearOfLiabilityForLicensing { get; private set; }

        public string RequestFinancialInterestInvite { get; private set; }

        public bool FinancialInterestAvailable { get; private set; }


        public bool PartialResponse { get; private set; }
        public bool HasErrors { get; private set; }

        public string ExpiredMessage
        {
            get
            {
                return
                    "This report is older than 15 days, we recommend you generate a new one as information may have changed since then";
            }
        }


       
    }
}
