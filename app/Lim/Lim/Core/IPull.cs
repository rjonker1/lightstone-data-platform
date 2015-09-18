namespace Lim.Core
{
    public interface IPull
    {
        void Pull(object command);
    }

    public interface IPull<in T> : IPull
    {
        void Pull(T command);
    }
}
