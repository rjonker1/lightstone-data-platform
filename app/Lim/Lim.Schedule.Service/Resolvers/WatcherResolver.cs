using Castle.Windsor;
using Lim.Core;

namespace Lim.Schedule.Service.Resolvers
{
    public class WatcherResolver : IWatch
    {
        private readonly IWindsorContainer _container;

        public WatcherResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public void Intialize(object command)
        {
            var type = command.GetType();
            var executorType = typeof (IWatch).MakeGenericType(type);
            var executor = (IWatch) _container.Resolve(executorType);
            Execute(command, executor);
        }

        public void Execute(object command, IWatch executor)
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
