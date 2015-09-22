using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Toolbox.Emailing.Domain;

namespace Lim.Schedule.Service.Installers
{
    public class EmailInstaller : IWindsorInstaller
    {
        private static readonly ILog Log = LogManager.GetLogger<FlatFileInstallers>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Log.Info("Installing Email Installers");

            container.Register(Classes.FromAssemblyContaining<Toolbox.Emailing.Smtp.HtmlMailMessageBuilder>()
                .BasedOn(typeof(IBuildMessage<,>))
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<Toolbox.Emailing.Smtp.SmtpMailDispatcher>()
               .BasedOn(typeof(IDispatchMail<>))
               .WithServiceAllInterfaces()
               .LifestyleTransient());

            Log.Info("Installed Email Installers");
        }
    }
}
