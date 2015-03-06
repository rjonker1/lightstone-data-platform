using PackageBuilder.Domain.Entities.Packages.WriteModels;
using PackageBuilder.TestObjects.Mothers;

namespace Lace.Test.Helper.Builders.Property
{
    public class LspSourcePackage
    {
        public static IPackage LspPackage()
        {

            return WritePackageMother.LspPackage;
        }

        
    }
}
