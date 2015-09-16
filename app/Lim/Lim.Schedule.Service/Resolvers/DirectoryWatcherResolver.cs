using Castle.Windsor;
using Lim.Core;

namespace Lim.Schedule.Service.Resolvers
{
    public class DirectoryWatcherResolver : IWatchDirectory
    {
        private readonly IWindsorContainer _container;

        public DirectoryWatcherResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public void Intialize(object command)
        {
            var type = command.GetType();
            var executorType = typeof (IWatchDirectory).MakeGenericType(type);
            var executor = (IWatchDirectory) _container.Resolve(executorType);
            Execute(command, executor);
        }

        public void Execute(object command, IWatchDirectory executor)
        {
            try
            {
               executor.Intialize(command);
            }
            finally
            {
                _container.Release(executor);
            }
        }
    }
}
