using System;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using PackageBuilder.TestObjects.Builders;
using PackageBuilder.TestObjects.Mothers;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberRgtVinRequestPackage
    {
        public static IPackage LicenseNumberPackage()
        {
            return LicensePlateSearchPackage;
        }

        //private static DataProviderCommandSource RgtVin
        //{
        //    get
        //    {
        //        return new WriteDataProviderBuilder()
        //            .With(DataProviderName.RgtVin)
        //            .With("RgtVin")
        //            .With(10d)
        //            .With(typeof(IProvideDataFromRgtVin))
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
                    .With(WriteDataProviderMother.RgtVin)
                    .Build();
            }
        }
    }
}
