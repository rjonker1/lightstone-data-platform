using Castle.Windsor;
using PackageBuilder.Api.Installers;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Industries.Read;
using PackageBuilder.TestHelper;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.Installers
{
    public class when_installing_repositories : Specification
    {
        readonly IWindsorContainer _container = new WindsorContainer();

        public override void Observe()
        {
            _container.Kernel.ComponentModelCreated += OverrideHelper.OverrideContainerLifestyle;
            _container.Install(new NHibernateInstaller(), new RepositoryInstaller());
            OverrideHelper.OverrideNhibernateCfg(_container);

        }

        [Observation]
        public void should_resolve_generic_repository()
        {
            _container.Resolve<IRepository<Industry>>().ShouldNotBeNull();
        }

        [Observation]
        public void should_resolve_generic_named_repository()
        {
            _container.Resolve<INamedEntityRepository<Industry>>().ShouldNotBeNull();
        }
    }
}