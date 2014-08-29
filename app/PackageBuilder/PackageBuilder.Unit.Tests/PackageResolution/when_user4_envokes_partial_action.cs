using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.Domain.Contracts.Enitities;
using PackageBuilder.TestHelper.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.PackageResolution
{
    public class when_user4_envokes_partial_action : Specification
    {
        private readonly IPackageLookupRepository _packageLookupRepository;
        private IPackage _package;
        public when_user4_envokes_partial_action()
        {
            _packageLookupRepository = PackageLookupMother.GetAcmeScenario();
        }

        public override void Observe()
        {
            _package = _packageLookupRepository.Get("user4", "Partial");
        }

        [Observation]
        public void package_is_returned()
        {
            _package.Name.ShouldEqual("Partial verification");
        }
    }
}