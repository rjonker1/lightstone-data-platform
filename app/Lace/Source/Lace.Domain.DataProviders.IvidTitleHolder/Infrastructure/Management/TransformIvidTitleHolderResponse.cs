using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;

namespace Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Management
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
