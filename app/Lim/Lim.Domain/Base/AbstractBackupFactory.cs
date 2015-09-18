using Lim.Core;

namespace Lim.Domain.Base
{
    public abstract class AbstractBackupFactory<T> : IBackup<T>
    {
        public abstract bool Backup(T command);

        public bool Backup(object command)
        {
           return Backup((T)command);
        }
    }
}