using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.PackageResolution
{
    public class when_user5_belonging_to_group3_and_role1_invokes_partial_action : Specification
    {
        private readonly IPackageLookupRepository _packageLookupRepository;
        private IPackage _package;
        public when_user5_belonging_to_group3_and_role1_invokes_partial_action()
        {
            //_packageLookupRepository = PackageLookupMother.GetAcmeScenario();
        }

        public override void Observe()
        {
            _package = _packageLookupRepository.Get("user5", "Partial");
        }

        [Observation]
        public void package_is_returned()
        {
            _package.Name.ShouldEqual("Partial verification");
        }
    }
}