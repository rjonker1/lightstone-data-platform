﻿using DataPlatform.Shared.Entities;
using PackageBuilder.TestHelper.Builders.Entites;

namespace PackageBuilder.TestHelper.Mothers
{
    public class DataFieldMother
    {
        public static IDataField ColourField
        {
            get
            {
                return new DataFieldBuilder().With("Colour").With(typeof(string)).Build();
            }
        }
        public static IDataField LicenseField
        {
            get
            {
                return new DataFieldBuilder().With("LicenceNo").With(typeof(string)).Build();
            }
        }
        public static IDataField BankNameField
        {
            get
            {
                return new DataFieldBuilder().With("BankName").With(typeof(string)).Build();
            }
        }
        public static IDataField AccidentClaimsField
        {
            get
            {
                return new DataFieldBuilder().With("AccidentClaims").With(typeof(string)).Build();
            }
        }
    }
}