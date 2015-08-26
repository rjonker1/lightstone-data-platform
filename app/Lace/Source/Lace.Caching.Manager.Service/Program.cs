using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Castle.Windsor.Installer;
using Lace.Domain.DataProviders.Core.Configuration;
using Topshelf;

namespace Lace.Caching.Manager.Service
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var container = new WindsorContainer(new XmlInterpreter()).Install(FromAssembly.This());
            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel));

            HostFactory.Run(x =>
            {
                x.Service<ICacheWorker>(s =>
                {
                    s.ConstructUsing(name => new CacheWorker(container));
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc =>
                    {
                        tc.End();
                        container.Release(tc);
                        container.Dispose();
                    });
                });
                x.RunAsLocalSystem();

                x.SetDescription(CachingConfiguration.ServiceDescription);
                x.SetDisplayName(CachingConfiguration.ServiceDisplayName);
                x.SetServiceName(CachingConfiguration.ServiceName);
            });
        }
    }
}