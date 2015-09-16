using Castle.Windsor;
using Lim.Core;

namespace Lim.Schedule.Service.Resolvers
{
    public class BackupFileResolver : IBackupFile
    {
        private readonly IWindsorContainer _container;

        public BackupFileResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public bool Backup(object command)
        {
            var type = command.GetType();
            var executorType = typeof (IBackupFile<>).MakeGenericType(type);
            var executor = (IBackupFile) _container.Resolve(executorType);
            return ExecuteHandler(command, executor);
        }

        private bool ExecuteHandler(object command, IBackupFile executor)
        {
            try
            {
                return executor.Backup(command);
            }
            finally
            {
                _container.Release(executor);
            }
        }

    }
}
