using Lace.Domain.Core.Requests.Contracts.RequestFields;
using Lace.Domain.Core.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IAmVinRequest : IAmDataProviderRequest
    {
        IAmVinNumberRequestField VinNumber { get; }
    }
}