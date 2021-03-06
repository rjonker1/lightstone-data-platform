using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.PackageResolution
{
    public class when_user_belonging_to_group2_invokes_ezscore_action : Specification
    {
        private readonly IPackageLookupRepository _packageLookupRepository;
        private IPackage _package;
        public when_user_belonging_to_group2_invokes_ezscore_action()
        {
            //_packageLookupRepository = PackageLookupMother.GetAcmeScenario();
        }

        public override void Observe()
        {
            _package = _packageLookupRepository.Get("user2", "Get EzScore");
        }

        [Observation]
        public void package_is_returned()
        {
            _package.Name.ShouldEqual("EzScore");
        }
    }
}