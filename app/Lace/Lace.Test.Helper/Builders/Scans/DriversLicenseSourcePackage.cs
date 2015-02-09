using PackageBuilder.Domain.Entities.Packages.WriteModels;
using PackageBuilder.TestObjects.Mothers;

namespace Lace.Test.Helper.Builders.Scans
{
    public class DriversLicenseSourcePackage
    {
        public static IPackage DriversLicenseDecryptionPackage()
        {

            return WritePackageMother.LicenseScanPackage;
        }

        //private static PackageBuilder.Domain.Entities.DataProviders.WriteModels.DataProvider SignioDriversLicenseDecryption
        //{
        //    get
        //    {
        //        return new WriteDataProviderBuilder()
        //            .With(DataProviderName.SignioDecryptDriversLicense)
        //            .With("Signio")
        //            .With(10d)
        //            .With(typeof(IProvideDataFromSignioDriversLicenseDecryption))
        //            .Build();
        //    }
        //}
        //private static Package LicensePlateSearchPackage
        //{
        //    get
        //    {
        //        return new WritePackageBuilder()
        //            .With("Drivers License")
        //            .With(10d, 20d)
        //            .With(DriversLicenseDecryptionAction)
        //            .With(IndustryMother.Finance, IndustryMother.Automotive)
        //            .With(StateMother.Published)
        //            .With(0.1m)
        //            .With(DateTime.Now)
        //            .With(SignioDriversLicenseDecryption)
        //            .Build();
        //    }
        //}

        //public static IAction DriversLicenseDecryptionAction
        //{
        //    get
        //    {
        //        return new ActionBuilder()
        //                    .With("Drivers License")
        //                    .Build();
        //    }
        //}
    }
}
