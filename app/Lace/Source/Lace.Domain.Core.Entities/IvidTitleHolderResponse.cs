using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class IvidTitleHolderResponse : IProvideDataFromIvidTitleHolder, IBuildIvidTitleHolderResponse
    {
        private const string NotAvailableError = "Error - Not Available";

        public IvidTitleHolderResponse()
        {

        }

        private IvidTitleHolderResponse(string message)
        {
            HasCriticalFailure = true;
            CriticalFailureMessage = message;
        }

        public void Build(string bankName, bool flaggedOnAnpr, string accountNumber, DateTime accountOpenDate, DateTime accountCloseDate,
            string yearOfLiablilityForLicensing)
        {
            BankName = CheckPartial(bankName);
            FlaggedOnAnpr = flaggedOnAnpr;
            AccountNumber = CheckPartial(accountNumber);
            AccountOpenDate = FormatDate(accountOpenDate);
            AccountClosedDate = FormatDate(accountCloseDate);
            YearOfLiabilityForLicensing = CheckPartial(yearOfLiablilityForLicensing);
        }

        public static IvidTitleHolderResponse Failure(string message)
        {
            return new IvidTitleHolderResponse(message);
        }

        public static IvidTitleHolderResponse Empty()
        {
            return new IvidTitleHolderResponse();
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
                    : BankName.ToLowerInvariant(), !string.IsNullOrEmpty(AccountNumber));

            validation.Check();

            FinancialInterestAvailable = validation.FinancedInterestIsAvailable;
            RequestFinancialInterestInvite = validation.FinancialInterestInvite;

        }

        [DataMember]
        public IAmIvidTitleholderRequest Request { get; private set; }

        [DataMember]
        public string BankName { get; private set; }

        [DataMember]
        public string AccountNumber { get; private set; }

        [DataMember]
        public DateTime? DateOpened { get; private set; }

        [DataMember]
        public bool FlaggedOnAnpr { get; private set; }

        [DataMember]
        public string FinancialInterestsHeading
        {
            get { return "Financial Interests"; }
        }

        [DataMember]
        public string AccountOpenDate { get; private set; }

        [DataMember]
        public string AccountClosedDate { get; private set; }

        [DataMember]
        public string AgreementType
        {
            get { return "Regular Finance Contract"; }
        }

        [DataMember]
        public string YearOfLiabilityForLicensing { get; private set; }

        [DataMember]
        public string RequestFinancialInterestInvite { get; private set; }

        [DataMember]
        public bool FinancialInterestAvailable { get; private set; }

        [DataMember]
        public bool PartialResponse { get; private set; }

        [DataMember]
        public bool HasErrors { get; private set; }

        [DataMember]
        public string ExpiredMessage
        {
            get
            {
                return
                    "This report is older than 15 days, we recommend you generate a new one as information may have changed since then";
            }
        }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
        }

        [DataMember]
        public Type Type
        {
            get { return GetType(); }
        }

        [DataMember]
        public bool Handled { get; private set; }

        [DataMember]
        public bool HasCriticalFailure { get; private set; }

        [DataMember]
        public string CriticalFailureMessage { get; private set; }

        public void HasNotBeenHandled()
        {
            Handled = false;
        }

        public void HasBeenHandled()
        {
            Handled = true;
        }
    }
}