using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.Xds
{
    public interface IRespondWithIdentityVerification : IProvideType
    {
        int ConsumerId { get; }
        string HomeAffairsId { get; }
        long IdNumber { get; }
        string FirstName { get; }
        string SecondName { get; }
        string Surname { get; }
        string DeceasedStatus { get; }
        string IdIssuedDate { get; }
        string CauseOfDeath { get; }
        long EnquiryId { get; }
        long EnquiryResultId { get; }
        string Reference { get; }
    }
}
