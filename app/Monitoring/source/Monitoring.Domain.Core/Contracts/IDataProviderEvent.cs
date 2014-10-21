using System;
namespace Monitoring.Domain.Core.Contracts
{
    public interface IDataProviderEvent
    {
        Guid Id { get; }
        Guid AggregateId { get; }
        int DataProviderId { get; }
        string Message { get; }
        DateTime Date { get; }
    }
}
