using PackageBuilder.Domain.Entities.Packages.Write;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.TestObjects.Tests
{
    public class when_calling_write_package_mother : Specification
    {
        private Package _package;
        public override void Observe()
        {
            _package = WritePackageMother.FullVerificationPackage;
        }

        [Observation]
        public void should_create_write_package_instance()
        {
            _package.ShouldNotBeNull();
        }
    }
}