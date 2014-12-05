using PackageBuilder.Domain.Entities.Packages.WriteModels;
using PackageBuilder.TestObjects.Builders;
using Xunit.Extensions;

namespace PackageBuilder.TestObjects.Tests
{
    public class when_calling_write_package_builder : Specification
    {
        private Package _package;
        public override void Observe()
        {
            _package = new WritePackageBuilder().With("Ivid").Build();
        }

        [Observation]
        public void should_create_write_package_instance()
        {
            _package.ShouldNotBeNull();
        }
    }
}
