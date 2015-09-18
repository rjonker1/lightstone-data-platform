using Castle.Windsor;
using Lim.Core;

namespace Lim.Schedule.Service.Resolvers
{
    public class AuditorResolver : IAudit
    {
        private readonly IWindsorContainer _container;

        public AuditorResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public void Audit(object command)
        {
            var type = command.GetType();
            var executorType = typeof(IAudit<>).MakeGenericType(type);
            var executor = (IAudit)_container.Resolve(executorType);
            Execute(command, executor);
        }

        private void Execute(object command, IAudit executor)
        {
            try
            {
                executor.Audit(command);
            }
            finally
            {
                _container.Release(executor);
            }
        }
    }
}
