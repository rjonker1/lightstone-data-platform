using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Castle.Windsor.Installer;
using Topshelf;

namespace Lim.Schedule.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer(new XmlInterpreter()).Install(FromAssembly.This());
            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel));

            HostFactory.Run(r =>
            {
                r.Service<IScheduleLimIntegration>(s =>
                {
                    s.ConstructUsing(name => new ScheduleWorker(container));
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc =>
                    {
                        tc.End();
                        container.Release(tc);
                        container.Dispose();
                    });
                });
                r.RunAsLocalSystem();

                r.SetDescription(System.Configuration.ConfigurationManager.AppSettings["service/config/description"]);
                r.SetDisplayName(System.Configuration.ConfigurationManager.AppSettings["service/config/displayName"]);
                r.SetServiceName(System.Configuration.ConfigurationManager.AppSettings["service/config/name"]);
            });
        }
    }
}
