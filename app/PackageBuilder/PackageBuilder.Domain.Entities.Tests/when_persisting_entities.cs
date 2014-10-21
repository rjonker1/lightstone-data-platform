using Castle.Windsor;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using PackageBuilder.Api.Installers;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Entities.Tests
{
    public class when_persisting_entities : Specification
    {
        public IWindsorContainer Container = new WindsorContainer();
        protected ISession Session;

        public override void Observe()
        {
            Container.Install(new NHibernateInstaller());
            new SchemaExport(Container.Resolve<NHibernate.Cfg.Configuration>()).Create(false, true);
            Session = Container.Resolve<ISessionFactory>().OpenSession();
        }
    }
}
