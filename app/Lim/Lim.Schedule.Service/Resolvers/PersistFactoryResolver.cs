using Castle.Windsor;
using Lim.Core;

namespace Lim.Schedule.Service.Resolvers
{
    public class PersistFactoryResolver : IPersistObject
    {
        private readonly IWindsorContainer _container;

        public PersistFactoryResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public bool Persist(object obj)
        {
            var type = obj.GetType();
            var executorType = typeof (IPersistObject<>).MakeGenericType(type);
            var executor = (IPersistObject) _container.Resolve(executorType);
            return ExecuteHandler(obj, executor);
        }

        public bool ExecuteHandler(object obj, IPersistObject executor)
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
