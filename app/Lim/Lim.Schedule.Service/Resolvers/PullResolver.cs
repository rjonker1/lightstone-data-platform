using Castle.Windsor;
using Lim.Core;

namespace Lim.Schedule.Service.Resolvers
{
    public class PullResolver : IPull
    {
        private readonly IWindsorContainer _container;

        public PullResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public void Pull(object command)
        {
            var type = command.GetType();
            var executorType = typeof (IPull<>).MakeGenericType(type);
            var executor = (IPull) _container.Resolve(executorType);
            Execute(command, executor);
        }

        public void Execute(object command, IPull executor)
        {
            try
            {
                executor.Pull(command);
            }
            finally
            {
                _container.Release(executor);
            }
        }
    }
}
