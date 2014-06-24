using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.TestHelper.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests
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
        public void then_should_return_verfify_package()
        {
            _package.Name.ShouldEqual("Partial verification");
        }
    }
}
