using PackageBuilder.Domain.Entities.Contracts.Packages.Write;
using PackageBuilder.TestObjects.Mothers;

namespace Lace.Test.Helper.Builders.Property
{
    public class PropertySourcePackage
    {
        public static IPackage PropertyPackage()
        {

            return WritePackageMother.PropertyPackage;
        }
    }
}
