using Castle.Windsor;
using Lim.Core;

namespace Lim.Schedule.Service.Resolvers
{
    public class ReadFileFactoryResolver : IReadFile
    {
        private readonly IWindsorContainer _container;

        public ReadFileFactoryResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public object ReadFile(object command)
        {
            var type = command.GetType();
            var executorType = typeof (IReadFile<,>).MakeGenericType(type);
            var executor = (IReadFile)_container.Resolve(executorType);
            return ExecuteHandler(command, executor);
        }

        private object ExecuteHandler(object command, IReadFile executor)
        {
            try
            {
                return executor.ReadFile(command);
            }
            finally
            {
                _container.Release(executor);
            }
        }
    }
}
