using System.Linq;
using System.Reflection;
using PackageBuilder.Api.Helpers.AutoMapper.Maps;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.Installers
{
    public class when_installing_auto_mapper : BaseTestHelper
    {
        public override void Observe()
        {

        }

        [Observation]
        public void should_resolve_ICreateAutoMapperMaps()
        {
            var registeredMappers = Core.Helpers.Extensions.TypeExtensions.FindDerivedTypesFromAssembly(Assembly.GetAssembly(typeof(ICreateAutoMapperMaps)), typeof(ICreateAutoMapperMaps), true, false).OrderBy(x => x.Name).ToList();
            var resolvedMappers = Container.ResolveAll<ICreateAutoMapperMaps>().Select(x => x.GetType()).OrderBy(x => x.Name).ToList();

            registeredMappers.ShouldEqual(resolvedMappers);
        }
    }
}