using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Industries.Read;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.Installers
{
    public class when_installing_repositories : BaseTestHelper
    {
        public override void Observe()
        {
            
        }

        [Observation]
        public void should_resolve_generic_repository()
        {
            Container.Resolve<IRepository<Industry>>().ShouldNotBeNull();
        }

        [Observation]
        public void should_resolve_generic_named_repository()
        {
            Container.Resolve<INamedEntityRepository<Industry>>().ShouldNotBeNull();
        }
    }
}