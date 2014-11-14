using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.PackageResolution
{
    public class when_user_belonging_to_group1_invokes_license_scan_action : Specification
    {
        private readonly IPackageLookupRepository _packageLookupRepository;
        private IPackage _package;
        public when_user_belonging_to_group1_invokes_license_scan_action()
        {
            //_packageLookupRepository = PackageLookupMother.GetAcmeScenario();
        }

        public override void Observe()
        {
            _package = _packageLookupRepository.Get("user1", "License Scan");
        }

        [Observation]
        public void package_is_returned()
        {
            _package.Name.ShouldEqual("Driver’s license scan package");
        }
    }
}