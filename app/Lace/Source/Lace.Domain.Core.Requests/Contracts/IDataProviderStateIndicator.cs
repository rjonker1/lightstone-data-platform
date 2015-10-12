using DataPlatform.Shared.Enums;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IDataProviderStateIndicator
    {
        DataProviderState State { get; }
    }
}
