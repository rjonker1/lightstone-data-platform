using Castle.Windsor;
using Lim.Core;

namespace Lim.Schedule.Service.Resolvers
{
    public class BackupFactoryResolver : IBackup
    {
        private readonly IWindsorContainer _container;

        public BackupFactoryResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public bool Backup(object command)
        {
            var type = command.GetType();
            var executorType = typeof (IBackup<>).MakeGenericType(type);
            var executor = (IBackup) _container.Resolve(executorType);
            return ExecuteHandler(command, executor);
        }

        private bool ExecuteHandler(object command, IBackup executor)
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
