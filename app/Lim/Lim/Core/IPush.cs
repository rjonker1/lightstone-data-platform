namespace Lim.Core
{
    public interface IPush
    {
        void Push(object command);
    }

    public interface IPush<in T> : IPush
    {
        void Push(T command);
    }
}
