using Castle.Windsor;
using PackageBuilder.Api.Installers;
using Xunit.Extensions;

namespace PackageBuilder.TestHelper.BaseTests
{
    public class when_not_persisting_entities : Specification
    {
        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller(), new NHibernateInstaller(), new RepositoryInstaller());
            OverrideHelper.OverrideNhibernateCfg(container);
        }
    }
}