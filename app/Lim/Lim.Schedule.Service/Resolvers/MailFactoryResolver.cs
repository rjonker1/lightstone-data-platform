using Castle.Windsor;
using Toolbox.Emailing.Domain;

namespace Lim.Schedule.Service.Resolvers
{
    public class MessageBuilderResolver : IBuildMessage
    {
         private readonly IWindsorContainer _container;

         public MessageBuilderResolver(IWindsorContainer container)
        {
            _container = container;
        }

         public object Build(object message)
        {
            var type = message.GetType();
            var executorType = (typeof (IBuildMessage<,>)).MakeGenericType(type);
            var executor = (IBuildMessage) _container.Resolve(executorType);
            return Execute(message, executor);
        }

         public object Execute(object message, IBuildMessage executor)
        {
            try
            {
                return executor.Build(message);
            }
            finally
            {
                _container.Release(executor);
            }
        }
    }

    public class DispatchMailResolver : IDispatchMail
    {
        private readonly IWindsorContainer _container;

        public DispatchMailResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public void Send(object message)
        {
            var type = message.GetType();
            var executorType = (typeof (IDispatchMail<>)).MakeGenericType(type);
            var executor = (IDispatchMail) _container.Resolve(executorType);
            Execute(message, executor);
        }

        public void Execute(object message, IDispatchMail executor)
        {
            try
            {
                executor.Send(message);
            }
            finally
            {
                _container.Release(executor);
            }
        }
    }
}
