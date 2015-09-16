namespace Lim.Core
{
    public interface IBackupFile
    {
        bool Backup(object command);
    }

    public interface IBackupFile<in T> : IBackupFile
    {
        bool Backup(T command);
    }
}