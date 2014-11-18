namespace Monitoring.Domain.Messages.Events
{
    public interface DataProviderRequestSentEvent : IDataProviderMonitoringEvent
    {
        string Payload { get; }
    }
}
