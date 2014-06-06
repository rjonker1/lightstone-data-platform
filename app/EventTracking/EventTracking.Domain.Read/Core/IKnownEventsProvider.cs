using EventStore.ClientAPI;

namespace EventTracking.Domain.Read.Core
{
    public interface IKnownEventsProvider
    {
        KnownEvent Get(RecordedEvent recordedEvent);
    }
}
