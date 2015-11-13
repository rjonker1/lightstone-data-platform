namespace EventTracking.Domain.Core.Contracts
{
    public interface IUpdateStorage : IQueryStorage
    {
        void Add<TItem>(TItem item) where TItem : class;
        void Remove<TItem>(TItem item) where TItem : class;
        void Update<TItem>(TItem item) where TItem : class;
    }
}
