namespace EventTracking.Domain.Persistence
{
    public interface IPersistAnEvent
    {
        void Save(IAggregate aggregate);
    }
}
