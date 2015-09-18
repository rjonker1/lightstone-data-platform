namespace Lim.Core
{
    public interface IBackup
    {
        bool Backup(object command);
    }

    public interface IBackup<in T> : IBackup
    {
        bool Backup(T command);
    }
}