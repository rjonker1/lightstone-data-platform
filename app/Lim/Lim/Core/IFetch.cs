namespace Lim.Core
{
    public interface IFetch
    {
        object Fetch(object command);
    }

    public interface IFetch<in T, out TResult> : IFetch
    {
        TResult Fetch(T command);
    }
}
