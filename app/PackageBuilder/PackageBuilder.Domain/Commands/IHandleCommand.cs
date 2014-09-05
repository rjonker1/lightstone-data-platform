using Castle.Windsor;

namespace PackageBuilder.Domain.Commands
{
    public interface IHandleCommand
    {
        void Handle(object command);
    }

    public interface IHandleCommand<T> : IHandleCommand
    {
        void Handle(T command);
    }

    public abstract class BaseCommandHandler<T> : IHandleCommand<T>
    {
        public abstract void Handle(T command);

        public void Handle(object command)
        {
            Handle((T)command);
        }
    }

    public class CommandHandler : IHandleCommand
    {
        private readonly IWindsorContainer _container;

        public CommandHandler(IWindsorContainer container)
        {
            _container = container;
        }

        public void Handle(object message)
        {
            var type = message.GetType();
            var executorType = typeof(IHandleCommand<>).MakeGenericType(type);
            var executor = (IHandleCommand)_container.Resolve(executorType);
            executor.Handle(message);
        }
    }
}