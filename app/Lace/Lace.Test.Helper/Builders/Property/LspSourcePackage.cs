using PackageBuilder.Domain.Entities.Packages.WriteModels;
using PackageBuilder.TestObjects.Mothers;

namespace Lace.Test.Helper.Builders.Scans
{
    public class LspSourcePackage
    {
        public static IPackage DriversLicenseDecryptionPackage()
        {

            return WritePackageMother.LicenseScanPackage;
        }

        
    }
}
