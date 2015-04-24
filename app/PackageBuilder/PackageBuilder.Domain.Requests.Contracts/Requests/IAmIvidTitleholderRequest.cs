using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmIvidTitleholderRequest : IAmDataProviderRequest
    {
        IAmRequesterNameRequestField RequesterName { get; }
        IAmRequesterPhoneRequestField RequesterPhone { get; }
        IAmRequesterEmailRequestField RequesterEmail { get; }
        IAmVinNumberRequestField VinNumber { get; }
    }
}