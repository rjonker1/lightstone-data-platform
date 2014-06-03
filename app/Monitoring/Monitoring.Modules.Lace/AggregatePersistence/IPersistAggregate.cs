using EventTracking.Domain.Persistence;

namespace Monitoring.Modules.Lace.AggregatePersistence
{
    public interface IPersistAggregate
    {
        IRepository Repository { get; }
        void SaveAggregate();
    }
}
