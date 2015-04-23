using Lace.Domain.Core.Requests.Contracts.RequestFields;

namespace Lace.Domain.Core.Requests.Contracts.Requests
{
    public interface IAmLightstoneAutoRequest : IAmDataProviderRequest
    {
        IAmCarIdRequestField CarId { get; }
        IAmYearRequestField Year { get; }
        IAmMakeRequestField Make { get; }
        IAmVinNumberRequestField VinNumber { get; }
    }
}