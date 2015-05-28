namespace Lim.Domain.Entities.Contracts
{
    public interface IPersistObject<T> where T : class
    {
        bool Persist(T obj);
    }
}
