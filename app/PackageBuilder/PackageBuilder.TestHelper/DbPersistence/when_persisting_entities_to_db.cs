using System.IO;
using Castle.Windsor;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using PackageBuilder.Api.Installers;
using Xunit.Extensions;

namespace PackageBuilder.TestHelper.DbPersistence
{
    public class when_persisting_entities_to_db : Specification
    {
        public IWindsorContainer Container = new WindsorContainer();
        protected ISession Session;

        public override void Observe()
        {
            Container.Install(new NHibernateInstaller());
            Session = Container.Resolve<ISessionFactory>().OpenSession();

            new SchemaExport(Container.Resolve<NHibernate.Cfg.Configuration>()).Execute(true, true, false, Session.Connection, new StreamWriter(new MemoryStream()));
        }
    }
}
