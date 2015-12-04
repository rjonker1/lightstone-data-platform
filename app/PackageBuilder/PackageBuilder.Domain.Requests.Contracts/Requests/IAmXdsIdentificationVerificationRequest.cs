
using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmXdsIdentificationVerificationRequest : IAmDataProviderRequest
    {
        IAmIdentityNumberRequestField IdNumber { get; }
        IAmFirstNameRequestField FirstName { get; }
        IAmSurnameRequestField Surname { get; }
        IAmRequestReferenceRequestField ReferenceNumber { get; }
        IAmVoucherCodeRequestField Voucher { get; }

    }
}
