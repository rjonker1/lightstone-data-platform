using DataPlatform.Shared.Enums;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IBillStateIndicator
    {
        DataProviderNoRecordState NoRecordState { get; }
    }
}
