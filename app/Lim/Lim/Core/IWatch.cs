namespace Lim.Core
{
    public interface IWatch
    {
        void Intialize(object command);
    }

    public interface IWatch<in T> : IWatch
    {
        void Intialize(T command);
    }
}
