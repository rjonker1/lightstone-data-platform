using Castle.Windsor;
using MemBus;
using NHibernate.Cfg;
using PackageBuilder.Api.Installers;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.Installers
{
    public class when_installing_nhibernate : Specification
    {
        IWindsorContainer _container = new WindsorContainer();

        public override void Observe()
        {
            _container.Install(new NHibernateInstaller());
        }

        [Observation]
        public void should_resolve_configuration()
        {
            var configuration = _container.Resolve<Configuration>();
            configuration.Properties.Count.ShouldEqual(11);
            configuration.Properties["dialect"].ShouldEqual("NHibernate.Dialect.MsSql2008Dialect");
            configuration.Properties["connection.connection_string_name"].ShouldEqual("packageBuilder");
            configuration.Properties["connection.provider"].ShouldEqual("NHibernate.Connection.DriverConnectionProvider");
            configuration.Properties["connection.driver_class"].ShouldEqual("NHibernate.Driver.SqlClientDriver");
            configuration.Properties["connection.release_mode"].ShouldEqual("auto");
            configuration.Properties["cache.provider_class"].ShouldEqual("NHibernate.Caches.SysCache.SysCacheProvider, NHibernate.Caches.SysCache");
            configuration.Properties["cache.use_second_level_cache"].ShouldEqual("true");
            configuration.Properties["cache.use_query_cache"].ShouldEqual("true");
            configuration.Properties["current_session_context_class"].ShouldEqual("web");
        }
    }
}