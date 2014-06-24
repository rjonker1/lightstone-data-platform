﻿using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.TestHelper.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests
{
    public class when_user_belonging_to_group1 : Specification
    {
        private readonly IPackageLookupRepository _packageLookupRepository;
        private IPackage _package;
        public when_user_belonging_to_group1()
        {
            _packageLookupRepository = PackageLookupMother.GetAcmeScenario();
        }

        public override void Observe()
        {
            _package = _packageLookupRepository.Get("user1", "License Scan");
        }

        [Observation]
        public void then_should_return_license_scan_package()
        {
            _package.Name.ShouldEqual("Driver’s license scan package");
        }
    }
}