using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.TestObjects.Builders;

namespace PackageBuilder.TestObjects.Mothers
{
    public class WriteDataProviderMother
    {
        public static DataProvider Ivid
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.Ivid)
                    .With("Ivid")
                    .With(DateTime.UtcNow)
                    .With((DateTime?) DateTime.UtcNow.AddDays(1))
                    .With(true)
                    .With(10d)
                    .With(typeof (IProvideDataFromIvid))
                    .With(DataFieldMother.CarFullname, DataFieldMother.CategoryCode, DataFieldMother.CategoryDescription,
                        DataFieldMother.ColourCode, DataFieldMother.CategoryDescription,
                        DataFieldMother.SpecificInformation)
                    .Build();
            }
        }

        public static DataProvider IvidTitleHolder
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.IvidTitleHolder)
                    .With("IvidTitleHolder")
                    .With(10d)
                    .With(typeof (IProvideDataFromIvidTitleHolder))
                    .Build();
            }
        }

        public static IDataProvider RgtVin
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.RgtVin)
                    .With("RgtVin")
                    .With(10d)
                    .With(typeof (IProvideDataFromRgtVin))
                    .Build();
            }
        }

        public static IDataProvider Rgt
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.Rgt)
                    .With("Rgt")
                    .With(10d)
                    .With(typeof (IProvideDataFromRgt))
                    .Build();
            }
        }

        public static IDataProvider Audatex
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.Audatex)
                    .With("Audatex")
                    .With(10d)
                    .With(typeof (IProvideDataFromAudatex))
                    .Build();
            }
        }

        public static DataProvider Lightstone
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.Lightstone)
                    .With("Lightstone")
                    .With(10d)
                    .With(typeof (IProvideDataFromLightstone))
                    .Build();
            }
        }

        public static DataProvider SignioDriversLicenseDataProvider
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.SignioDecryptDriversLicense)
                    .With("Signio")
                    .With(10d)
                    .With(typeof (IProvideDataFromSignioDriversLicenseDecryption))
                    .Build();
            }
        }

        public static DataProvider PCubedFicaDataProvider
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.PCubedFica)
                    .With("PCubed")
                    .With(10d)
                    .With(typeof (IProvideDataFromPCubedFicaVerfication))
                    .Build();
            }
        }

        public static DataProvider LightstoneDataProvider
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.Lsp)
                    .With("LightstoneProperty")
                    .With(10d)
                    .With(typeof (IProvideDataFromLightstoneProperty))
                    .Build();
            }
        }
    }
}