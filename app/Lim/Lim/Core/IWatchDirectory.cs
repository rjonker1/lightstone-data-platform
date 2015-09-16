namespace Lim.Core
{
    public interface IWatchDirectory
    {
        void Intialize(object command);
    }

    public interface IWatchDirectory<in T> : IWatchDirectory
    {
        void Intialize(T command);
    }
}
