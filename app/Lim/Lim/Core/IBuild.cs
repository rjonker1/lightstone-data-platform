namespace Lim.Core
{
    public interface IBuild
    {
        object Build(object @object);
    }

    public interface IBuild<in T, out TResult> : IBuild
    {
        TResult Build(T @object);
    }
}