using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmPCubedEzScoreRequest : IAmDataProviderRequest
    {
        IAmIdentityNumberRequestField IdNumber { get; }
        IAmPhoneNumberRequestField PhoneNumber { get; }
        IAmEmailAddressRequestField EmailAddress { get; }
    }
}