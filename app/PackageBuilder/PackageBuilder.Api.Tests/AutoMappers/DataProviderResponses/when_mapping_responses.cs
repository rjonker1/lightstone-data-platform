using Castle.Windsor;
using PackageBuilder.Api.Installers;
using PackageBuilder.TestHelper;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMappers.DataProviderResponses
{
    public class when_mapping_responses : Specification
    {
        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Kernel.ComponentModelCreated += OverrideHelper.OverrideContainerLifestyle;
            container.Install(new AutoMapperInstaller(), new NHibernateInstaller(), new RepositoryInstaller());

            OverrideHelper.OverrideNhibernateCfg(container);
        }
    }
}