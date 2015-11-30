using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;

namespace UserManagement.Domain.Core.MessageHandling
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
            if( message == null) return;
            var type = message.GetType();
            var executorType = typeof(IHandleMessages<>).MakeGenericType(type);
            var executor = (IHandleMessages)_container.TryResolve(executorType);
            if (executor == null) return;
            executor.Handle(message);
        }
    }
}