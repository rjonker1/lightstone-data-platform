namespace EventTracking.Domain.Persistence
{
    public interface IPersistEvent
    {
        void Save(IAggregate aggregate);
    }
}
