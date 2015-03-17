using Castle.Windsor;

namespace Billing.Domain.Core.MessageHandling
{
    public interface IHandleMessages
    {
        void Handle(object command);
    }

    public class MessageHandlerResolver : IHandleMessages
    {

        private readonly IWindsorContainer _container;

        public MessageHandlerResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public void Handle(object message)
        {
            var type = message.GetType();
            var executorType = typeof(IHandleMessages<>).MakeGenericType(type);
            var executor = (IHandleMessages)_container.Resolve(executorType);
            executor.Handle(message);
        }
    }
}