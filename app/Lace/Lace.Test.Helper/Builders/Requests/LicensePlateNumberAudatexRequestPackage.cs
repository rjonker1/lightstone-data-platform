﻿using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using PackageBuilder.TestObjects.Builders;
using PackageBuilder.TestObjects.Mothers;


namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberAudatexRequestPackage
    {
        public static IPackage LicenseNumberPackage()
        {

            return LicensePlateSearchPackage;
        }

        private static DataProvider Audatex
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.Audatex)
                    .With("Audatex")
                    .With(10d)
                    .With(typeof(IProvideDataFromAudatex))
                    .Build();
            }
        }

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
                    .With(Audatex)
                    .Build();
            }
        }
    }

    
}
