namespace Lim.Core
{
    public interface IRead
    {
        object Read(object command);
    }

    public interface IRead<in T1, out T2> : IRead
    {
        T2 Read(T1 command);
    }
}
