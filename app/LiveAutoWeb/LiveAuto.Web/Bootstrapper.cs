using Castle.Windsor;
using LiveAuto.Web.Installers;
using Nancy.Bootstrappers.Windsor;
using Nancy.Conventions;

namespace LiveAuto.Web
{
    public class Bootstrapper : WindsorNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            // Perform registations that should have an application lifetime
            base.ConfigureApplicationContainer(container);

            container.Install(new ApiClientInstaller());

            //Drop create
            //new SchemaExport(container.Resolve<NHibernate.Cfg.Configuration>()).Create(false, true);
        }
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/AdminLteTemplate"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/Content"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/fonts"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/font-awesome"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/Scripts"));
        }
    }
}