using DataPlatform.Shared.Entities;

namespace PackageBuilder.TestHelper.Mothers
{
    public class PackageMother
    {
        public static IPackage LicensePlateSearchPackage
        {
            get
            {
                return new Builders.Entites.PackageBuilder()
                    .With("License plate search")
                    .With(ActionMother.LicensePlateSearchAction)
                    .With(DataSetMother.VehicleVerification,
                          DataSetMother.RepairHistory,
                          DataSetMother.ValuesHistory)
                    .Build();
            }
        }

        public static IPackage FullVerificationPackage
        {
            get
            {
                return new Builders.Entites.PackageBuilder()
                    .With("Full verification")
                    .With(ActionMother.AllAction)
                    .With(DataSetMother.VehicleVerification,
                          DataSetMother.RepairHistory,
                          DataSetMother.ValuesHistory)
                    .Build();
            }
        }

        public static IPackage PartialVerificationPackage
        {
            get
            {
                return new Builders.Entites.PackageBuilder()
                    .With("Partial verification")
                    .With(ActionMother.VerifyAction)
                    .With(DataSetMother.VehicleVerification, 
                          DataSetMother.LicenseScan, 
                          DataSetMother.ValuesHistory)
                    .Build();
            }
        }

        public static IPackage LicenseScanPackage
        {
            get
            {
                return new Builders.Entites.PackageBuilder()
                    .With("Driver’s license scan package")
                    .With(ActionMother.LicenseScanAction)
                    .With(DataSetMother.LicenseScan)
                    .Build();
            }
        }
        public static IPackage EzScorePackage
        {
            get
            {
                return new Builders.Entites.PackageBuilder()
                    .With("EzScore")
                    .With(ActionMother.EzScoreAction)
                    .With(DataSetMother.EzScore)
                    .Build();
            }
        }
    }
}