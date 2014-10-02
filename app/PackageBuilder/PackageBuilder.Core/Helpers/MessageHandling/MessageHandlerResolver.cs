using Castle.Windsor;

namespace PackageBuilder.Core.Helpers.MessageHandling
{
    public interface IHandleMessages
    {
        void Handle(object command);
    }

    public class MessagesHandlerResolver : IHandleMessages
    {
        private readonly IWindsorContainer _container;

        public MessagesHandlerResolver(IWindsorContainer container)
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
