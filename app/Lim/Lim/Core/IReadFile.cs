namespace Lim.Core
{
    public interface IReadFile
    {
        object ReadFile(object command);
    }

    public interface IReadFile<in T1, out T2> : IReadFile
    {
        T2 ReadFile(T1 command);
    }
}
