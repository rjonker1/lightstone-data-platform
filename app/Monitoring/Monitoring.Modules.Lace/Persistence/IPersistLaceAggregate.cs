using EventTracking.Domain;

namespace Monitoring.Modules.Lace.Persistence
{
    public interface IPersistLaceAggregate
    {
        void Save(IAggregate aggregate);
    }
}
