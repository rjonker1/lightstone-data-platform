using DataPlatform.Shared.Entities;
using PackageBuilder.Acceptance.Tests.Mothers;
using PackageBuilder.Api;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests
{
    public class when_user5_belonging_to_group3 : Specification
    {
        private readonly IPackageLookupRepository _packageLookupRepository;
        private IPackage _package;
        public when_user5_belonging_to_group3()
        {
            _packageLookupRepository = PackageLookupMother.GetAcmeScenario();
        }

        public override void Observe()
        {
            _package = _packageLookupRepository.Get("user5", "Full");
        }

        [Observation]
        public void then_package_should_be_null()
        {
            _package.ShouldBeNull();
        }
    }
}