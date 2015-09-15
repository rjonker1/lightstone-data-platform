namespace Lim.Core
{ 
    public interface IPersistObject
    {
        bool Persist(object obj);
    }

    public interface IPersistObject<in T> : IPersistObject
    {
        bool Persist(T obj);
    }
}