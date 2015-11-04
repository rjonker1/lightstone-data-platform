using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Recoveries.Core.Messages;
using Recoveries.Domain.Base;

namespace Recoveries.Router.Installers
{
    public class ConsumerInstaller : IWindsorInstaller
    {
        private static readonly ILog Log = LogManager.GetLogger<ConsumerInstaller>();
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Register(container);
        }

        private static void Register(IWindsorContainer container)
        {
            var assemblies = new List<Assembly>()
            {
                typeof (RecoveriesMarker).Assembly
            };

            var recoverMessageType = typeof (IRecoverMessage);
            var consumerType = typeof (IConsumeMessages);

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes().Where(a => a.IsClass && !a.IsAbstract).ToList();
                foreach (var type in types.Where(consumerType.IsAssignableFrom))
                {
                    var interfaces = type.GetInterfaces().Where(i => i.IsGenericType);
                    foreach (var @interface in interfaces)
                    {
                        var messageType = @interface.GetGenericArguments();
                        foreach (var thisMessageType in messageType)
                        {
                            if (recoverMessageType.IsAssignableFrom(thisMessageType))
                            {
                                var currentConsumerType = typeof(IConsumeMessages<>).MakeGenericType(thisMessageType);
                                Log.InfoFormat("Registering {0} as a recovery message consumer handling {1}",type, thisMessageType);
                                if (!container.Kernel.HasComponent(currentConsumerType))
                                {
                                    container.Register(Component.For(currentConsumerType)
                                        .ImplementedBy(type)
                                        .LifestylePerThread()
                                        .Named(type.FullName));
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
