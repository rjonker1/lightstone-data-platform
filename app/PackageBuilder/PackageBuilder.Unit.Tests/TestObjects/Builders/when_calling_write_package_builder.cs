using PackageBuilder.Domain.Entities.Packages.Write;
using PackageBuilder.TestObjects.Builders;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.TestObjects.Builders
{
    public class when_calling_write_package_builder : Specification
    {
        private Package _package;
        public override async void Observe()
        {
            _package = await new WritePackageBuilder().With("Ivid").Build();
        }

        [Observation]
        public void should_create_write_package_instance()
        {
            _package.ShouldNotBeNull();
        }
    }
}
