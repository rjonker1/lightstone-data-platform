namespace Lim.Core
{
    public interface IFetchConfiguration
    {
        object Fetch(object command);
    }

    public interface IFetchConfiguration<in T, out TResult> : IFetchConfiguration
    {
        TResult Fetch(T command);
    }
}
