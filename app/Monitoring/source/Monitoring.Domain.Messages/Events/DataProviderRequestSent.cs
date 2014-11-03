namespace Monitoring.Domain.Messages.Events
{
    public interface DataProviderRequestSent : IDataProviderEvent
    {
        string Payload { get; }
    }
}
