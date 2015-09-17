namespace Lim.Core
{
    public interface IInitialize
    {
        void Init(object command);
    }

    public interface IInitialize<in T> : IInitialize
    {
        void Init(T command);
    }

}
