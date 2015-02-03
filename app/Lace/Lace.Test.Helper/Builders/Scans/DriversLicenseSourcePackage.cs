using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using PackageBuilder.TestObjects.Builders;
using PackageBuilder.TestObjects.Mothers;

namespace Lace.Test.Helper.Builders.Scans
{
    public class DriversLicenseSourcePackage
    {
        public static IPackage DriversLicenseDecryptionPackage()
        {

            return LicensePlateSearchPackage;
        }

        private static PackageBuilder.Domain.Entities.DataProviders.WriteModels.DataProvider SignioDriversLicenseDecryption
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.SignioDecryptDriversLicense)
                    .With("Signio")
                    .With(10d)
                    .With(typeof(IProvideDataFromSignioDriversLicenseDecryption))
                    .Build();
            }
        }
        private static Package LicensePlateSearchPackage
        {
            get
            {
                return new WritePackageBuilder()
                    .With("Drivers License Decryption")
                    .With(10d, 20d)
                    .With(ActionMother.EzScoreAction)
                    .With(IndustryMother.Finance, IndustryMother.Automotive)
                    .With(StateMother.Published)
                    .With(0.1m)
                    .With(DateTime.Now)
                    .With(SignioDriversLicenseDecryption)
                    .Build();
            }
        }
    }
}
