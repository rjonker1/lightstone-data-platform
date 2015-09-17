namespace Lim.Core
{
    public interface IPushConfiguration
    {
        void Push(object command);
    }

    public interface IPushConfiguration<in T> : IPushConfiguration
    {
        void Push(T command);
    }
}
