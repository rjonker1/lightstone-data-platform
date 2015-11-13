using Castle.Windsor;
using Lim.Core;

namespace Lim.Schedule.Service.Resolvers
{
    public class FailFactoryResolver : IFail
    {
        private readonly IWindsorContainer _container;

        public FailFactoryResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public bool Fail(object command)
        {
            var type = command.GetType();
            var executorType = typeof (IFail<>).MakeGenericType(type);
            var executor = (IFail) _container.Resolve(executorType);
            return ExecuteHandler(command, executor);
        }

        private bool ExecuteHandler(object command, IFail executor)
        {
            try
            {
                return executor.Fail(command);
            }
            finally
            {
                _container.Release(executor);
            }
        }

    }
}
