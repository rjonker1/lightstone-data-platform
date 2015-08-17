using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmPCubedEzScoreRequest
    {
        IAmIdentityNumberRequestField IdNumber { get; }
        IAmPhoneNumberRequestField PhoneNumber { get; }
        IAmEmailAddressRequestField EmailAddress { get; }
    }
}