namespace Lim.Core
{
    public interface IReadFile
    {
        object ReadFile(object command);
    }

    public interface IReadPasswordProtectedZipFile<in T1, out T2> : IReadFile
    {
        T2 ReadFile(T1 command);
    }
}
