using Castle.Windsor;
using Lim.Core;

namespace Lim.Schedule.Service.Resolvers
{
    public class PersistFactoryResolver : IPersist
    {
        private readonly IWindsorContainer _container;

        public PersistFactoryResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public bool Persist(object obj)
        {
            var type = obj.GetType();
            var executorType = typeof (IPersist<>).MakeGenericType(type);
            var executor = (IPersist) _container.Resolve(executorType);
            return ExecuteHandler(obj, executor);
        }

        public bool ExecuteHandler(object obj, IPersist executor)
        {
            try
            {
                return executor.Persist(obj);
            }
            finally
            {
                _container.Release(executor);
            }
        }
    }
}
