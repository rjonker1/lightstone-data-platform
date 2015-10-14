using DataPlatform.Shared.Enums;

namespace Lace.Domain.Core.Contracts.Requests
{
    public interface IProvideResponseState
    {
        DataProviderResponseState ResponseState { get; }
        string ResponseStateMessage { get; }
        void AddResponseState(DataProviderResponseState state);
    }
}
