using Castle.Windsor;
using NHibernate.Tool.hbm2ddl;
using PackageBuilder.Api.Installers;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests
{
    public class when_creating_nhibernate_schema : Specification
    {
        public override void Observe()
        {
            var windsorContainer = new WindsorContainer();
            windsorContainer.Install(new NHibernateInstaller());

            new SchemaExport(windsorContainer.Resolve<NHibernate.Cfg.Configuration>()).Create(false, true);
        }

        [Observation]
        public void should_create()
        {

        }
    }
}