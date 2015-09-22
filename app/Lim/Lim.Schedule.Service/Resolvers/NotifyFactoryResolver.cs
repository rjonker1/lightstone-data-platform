using Castle.Windsor;
using Lim.Core;

namespace Lim.Schedule.Service.Resolvers
{
    public class NotifyFactoryResolver : INotify
    {
        private readonly IWindsorContainer _container;

        public NotifyFactoryResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public void Notify(object message)
        {
            var type = message.GetType();
            var executorType = typeof (INotify<>).MakeGenericType(type);
            var executor = (INotify) _container.Resolve(executorType);
            Execute(message, executor);
        }

        private void Execute(object message, INotify executor)
        {
            try
            {
                executor.Notify(message);
            }
            finally
            {
                _container.Release(executor);
            }
        }
    }
}
