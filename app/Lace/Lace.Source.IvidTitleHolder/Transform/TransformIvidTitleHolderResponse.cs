using Lace.Models.IvidTitleHolder.DataObject;
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
            Result.Build(Message.bankName, Message.flaggedOnAnpr, Message.accountNumber, Message.accountOpenDate,
                Message.accountClosedDate, Message.yearOfLiabilityForLicensing);

            Result.SetRequestFinancialInterestInvite();
        }
    }
}
