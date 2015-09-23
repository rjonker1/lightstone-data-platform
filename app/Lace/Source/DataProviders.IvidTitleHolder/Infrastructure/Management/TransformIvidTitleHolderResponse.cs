using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Shared.Extensions;

namespace Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Management
{
    public sealed class TransformIvidTitleHolderResponse : ITransform
    {
        public TitleholderQueryResponse Message { get; private set; }
        public IvidTitleHolderResponse Result { get; private set; }
        public bool Continue { get; private set; }

        public TransformIvidTitleHolderResponse(TitleholderQueryResponse response, ICauseCriticalFailure criticalFailure)
        {
            Continue = response != null;
            Result = criticalFailure.IsCritical() ? IvidTitleHolderResponse.Failure(criticalFailure.Message) : IvidTitleHolderResponse.Empty();
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