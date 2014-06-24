using DataPlatform.Shared.Entities;

namespace PackageBuilder.TestHelper.Mothers
{
    public class PackageMother
    {
        public static IPackage LicensePlateSearchPackage
        {
            get
            {
                return Builders.Entites.PackageBuilder.Get("License plate search", ActionMother.LicensePlateSeacrhAction,
                    DataSetMother.VehicleVerification,
                    DataSetMother.RepairHistory,
                    DataSetMother.ValuesHistory);
            }
        }

        public static IPackage FullVerificationPackage
        {
            get
            {
                return Builders.Entites.PackageBuilder.Get("Full verification", ActionMother.AllAction, 
                    DataSetMother.VehicleVerification, 
                    DataSetMother.RepairHistory, 
                    DataSetMother.ValuesHistory);
            }
        }

        public static IPackage PartialVerificationPackage
        {
            get
            {
                return Builders.Entites.PackageBuilder.Get("Partial verification", ActionMother.VerifyAction, 
                    DataSetMother.VehicleVerification, 
                    DataSetMother.LicenseScan, 
                    DataSetMother.ValuesHistory);
            }
        }

        public static IPackage LicenseScanPackage
        {
            get
            {
                return Builders.Entites.PackageBuilder.Get("Driver’s license scan package", ActionMother.LicenseScanAction, DataSetMother.LicenseScan);
            }
        }
        public static IPackage EzScorePackage
        {
            get
            {
                return Builders.Entites.PackageBuilder.Get("EzScore", ActionMother.EzScoreAction, DataSetMother.EzScore);
            }
        }
    }
}