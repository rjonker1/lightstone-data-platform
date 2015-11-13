using Castle.Windsor;
using Lim.Core;

namespace Lim.Schedule.Service.Resolvers
{
    public class PushResolver : IPush
    {
        private readonly IWindsorContainer _container;

        public PushResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public void Push(object command)
        {
            var type = command.GetType();
            var executorType = typeof(IPush<>).MakeGenericType(type);
            var executor = (IPush)_container.Resolve(executorType);
            Execute(command, executor);
        }

        public void Execute(object command, IPush executor)
        {
            try
            {
                executor.Push(command);
            }
            finally
            {
                _container.Release(executor);
            }
        }
    }
}
