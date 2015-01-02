using System.Linq;
using System.Reflection;
using Castle.Windsor;
using PackageBuilder.Api.Helpers.AutoMapper.Maps;
using PackageBuilder.Api.Installers;
using PackageBuilder.TestHelper;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.Installers
{
    public class when_installing_auto_mapper : Specification
    {
        readonly IWindsorContainer _container = new WindsorContainer();

        public override void Observe()
        {
            _container.Kernel.ComponentModelCreated += OverrideHelper.OverrideContainerLifestyle;
            _container.Install(new NHibernateInstaller());
            OverrideHelper.OverrideNhibernateCfg(_container);

            _container.Install(new ServiceLocatorInstaller(), new RepositoryInstaller(), new AutoMapperInstaller());

        }

        [Observation]
        public void should_resolve_ICreateAutoMapperMaps()
        {
            var registeredMappers = Core.Helpers.Extensions.TypeExtensions.FindDerivedTypesFromAssembly(Assembly.GetAssembly(typeof(ICreateAutoMapperMaps)), typeof(ICreateAutoMapperMaps), true, false).OrderBy(x => x.Name).ToList();
            var resolvedMappers = _container.ResolveAll<ICreateAutoMapperMaps>().Select(x => x.GetType()).OrderBy(x => x.Name).ToList();

            registeredMappers.ShouldEqual(resolvedMappers);
        }
    }
}