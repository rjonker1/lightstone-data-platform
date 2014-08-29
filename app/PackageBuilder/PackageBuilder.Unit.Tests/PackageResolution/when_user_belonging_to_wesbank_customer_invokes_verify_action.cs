using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.Domain.Contracts.Enitities;
using PackageBuilder.TestHelper.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.PackageResolution
{
    public class when_user_belonging_to_wesbank_customer_invokes_verify_action : Specification
    {
        private readonly IPackageLookupRepository _packageLookupRepository;
        private IPackage _package;
        public when_user_belonging_to_wesbank_customer_invokes_verify_action()
        {
            _packageLookupRepository = PackageLookupMother.GetWesbankScenario();
        }

        public override void Observe()
        {
            _package = _packageLookupRepository.Get("TestUser", "Partial");
        }

        [Observation]
        public void package_is_returned()
        {
            _package.Name.ShouldEqual("Partial verification");
        }
    }
}
