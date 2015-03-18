using System;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;
using PackageBuilder.Domain.Entities.Packages.Write;
using PackageBuilder.TestObjects.Builders;
using PackageBuilder.TestObjects.Mothers;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberIvidSourcePackage
    {
        public static IPackage LicenseNumberPackage()
        {
            return LicensePlateSearchPackage;
        }

        //private static DataProviderCommandSource Ivid
        //{
        //    get
        //    {
        //        return new WriteDataProviderBuilder()
        //            .With(DataProviderName.Ivid)
        //            .With("Ivid")
        //            .With(10d)
        //            .With(typeof(IProvideDataFromIvid))
        //            .Build();
        //    }
        //}

        private static Package LicensePlateSearchPackage
        {
            get
            {
                return new WritePackageBuilder()
                    .With("License plate search")
                    .With(10d, 20d)
                    .With(ActionMother.LicensePlateSearchAction)
                    .With(IndustryMother.Finance, IndustryMother.Automotive)
                    .With(StateMother.Published)
                    .With(0.1m)
                    .With(DateTime.Now)
                    .With(WriteDataProviderMother.Ivid)
                    .Build();
            }
        }
    }
}
