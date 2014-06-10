using EventTracking.Domain;

namespace Monitoring.Consumer.Lace.Persistence
{
    public interface IPersistEvent
    {
        void Save(IAggregate aggregate);
    }
}
