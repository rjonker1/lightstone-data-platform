namespace Lim.Core
{ 
    public interface IPersist
    {
        bool Persist(object @object);
    }

    public interface IPersist<in T> : IPersist
    {
        bool Persist(T @object);
    }
}