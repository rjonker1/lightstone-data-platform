using System;
using Lace.Models.IvidTitleHolder.Dto;
using Lace.Source.IvidTitleHolder.IvidTitleHolderServiceReference;

namespace Lace.Source.IvidTitleHolder.Transform
{
    public class TransformIvidTitleHolderResponse : ITransform
    {
        public TitleholderQueryResponse Message { get; private set; }
        public IvidTitleHolderResponse Result { get; private set; }
        public bool Continue { get; private set; }

        public TransformIvidTitleHolderResponse(TitleholderQueryResponse response)
        {
            Continue = response != null;
            Result = Continue ? new IvidTitleHolderResponse() : null;
            Message = response;
        }

        public void Transform()
        {
            Result.PartialResponse = Message.partialResponse;
            Result.HasErrors = Message.partialResponse;
            Result.BankName = CheckPartialResults(Message.bankName);
            Result.FlaggedOnAnpr = Message.flaggedOnAnpr;
            Result.AccountNumber = CheckPartialResults(Message.accountNumber);
            
            Result.AccountOpenDate = FormatDate(Message.accountOpenDate);
            Result.AccountClosedDate = FormatDate(Message.accountClosedDate);

            Result.YearOfLiabilityForLicensing = Message.yearOfLiabilityForLicensing;

        }

        private const string NotAvailableError = "Error - Not Available";

        private static string FormatDate(DateTime? date)
        {
            if (!date.HasValue || date.Value == DateTime.MinValue) return NotAvailableError;

            return date.Value.ToString("dd MMMM yyyy");
        }

        private string CheckPartialResults(string value)
        {
            if (Result.HasErrors && string.IsNullOrWhiteSpace(value))
            {
                value = NotAvailableError;
            }
            return value;
        }

      
    }
}
