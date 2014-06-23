using DataPlatform.Shared.Entities;
using PackageBuilder.Acceptance.Tests.Mothers;
using PackageBuilder.Api;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests
{
    public class when_user_belonging_to_group2_envokes_ezscore_action : Specification
    {
        private readonly IPackageLookupRepository _packageLookupRepository;
        private IPackage _package;
        public when_user_belonging_to_group2_envokes_ezscore_action()
        {
            _packageLookupRepository = PackageLookupMother.GetAcmeScenario();
        }

        public override void Observe()
        {
            _package = _packageLookupRepository.Get("user2", "Get EzScore");
        }

        [Observation]
        public void then_should_return_license_scan_package()
        {
            _package.Name.ShouldEqual("EzScore");
        }
    }
}