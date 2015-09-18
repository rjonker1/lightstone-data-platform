using Castle.Windsor;
using Lim.Core;

namespace Lim.Schedule.Service.Resolvers
{
    public class InitializeResolver : IInitialize
    {
        private readonly IWindsorContainer _container;

        public InitializeResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public void Init(object command)
        {
            var type = command.GetType();
            var executorType = typeof(IInitialize<>).MakeGenericType(type);
            var executor = (IInitialize)_container.Resolve(executorType);
            Execute(command, executor);
        }

        public void Execute(object command, IInitialize executor)
        {
            try
            {
                executor.Init(command);
            }
            finally
            {
                _container.Release(executor);
            }
        }
    }
}
