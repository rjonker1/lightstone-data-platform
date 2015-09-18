using Castle.Windsor;
using Lim.Core;

namespace Lim.Schedule.Service.Resolvers
{
    public class ReadFactoryResolver : IRead
    {
        private readonly IWindsorContainer _container;

        public ReadFactoryResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public object Read(object command)
        {
            var type = command.GetType();
            var executorType = typeof (IRead<,>).MakeGenericType(type);
            var executor = (IRead)_container.Resolve(executorType);
            return ExecuteHandler(command, executor);
        }

        private object ExecuteHandler(object command, IRead executor)
        {
            try
            {
                return executor.Read(command);
            }
            finally
            {
                _container.Release(executor);
            }
        }
    }
}
