namespace Lim.Core
{ 
    public interface IPersist
    {
        bool Persist(object obj);
    }

    public interface IPersist<in T> : IPersist
    {
        bool Persist(T obj);
    }
}