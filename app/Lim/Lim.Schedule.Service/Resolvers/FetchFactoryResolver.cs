using Castle.Windsor;
using Lim.Core;

namespace Lim.Schedule.Service.Resolvers
{
    public class FetchFactoryResolver : IFetch
    {
        private readonly IWindsorContainer _container;

        public FetchFactoryResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public object Fetch(object command)
        {
            var type = command.GetType();
            var exectorType = typeof (IFetch<,>).MakeGenericType(type);
            var executor = (IFetch) _container.Resolve(exectorType);
            return Execute(command, executor);
        }

        public object Execute(object command, IFetch executor)
        {
            try
            {
                return executor.Fetch(command);
            }
            finally
            {
                _container.Release(executor);
            }
        }
    }
}