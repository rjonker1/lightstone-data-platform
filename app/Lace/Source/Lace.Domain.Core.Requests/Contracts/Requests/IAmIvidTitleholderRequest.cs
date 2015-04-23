using Lace.Domain.Core.Requests.Contracts.RequestFields;

namespace Lace.Domain.Core.Requests.Contracts.Requests
{
    public interface IAmIvidTitleholderRequest : IAmDataProviderRequest
    {
        IAmRequesterNameRequestField RequesterName { get; }
        IAmRequesterPhoneRequestField RequesterPhone { get; }
        IAmRequesterEmailRequestField RequesterEmail { get; }
        IAmVinNumberRequestField VinNumber { get; }
    }
}