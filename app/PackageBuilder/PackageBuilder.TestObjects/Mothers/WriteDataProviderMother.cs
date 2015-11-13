using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;
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
                    .With(DataProviderName.IVIDVerify_E_WS)
                    .With("Ivid")
                    .With("Ivid", "Owner")
                    .With(DateTime.UtcNow)
                    .With((DateTime?) DateTime.UtcNow.AddDays(1))
                    .With(true)
                    .With(10m)
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
                    .With(DataProviderName.IVIDTitle_E_WS)
                    .With("IvidTitleHolder")
                    .With(10m)
                    .With(typeof (IProvideDataFromIvidTitleHolder))
                    .Build();
            }
        }

        public static IDataProvider RgtVin
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.LSAutoVINMaster_I_DB)
                    .With("RgtVin")
                    .With(10m)
                    .With(typeof (IProvideDataFromRgtVin))
                    .Build();
            }
        }

        public static IDataProvider Rgt
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.LSAutoSpecs_I_DB)
                    .With("Rgt")
                    .With(10m)
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
                    .With(10m)
                    .With(typeof (IProvideDataFromAudatex))
                    .Build();
            }
        }

        public static DataProvider Lightstone
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.LSAutoCarStats_I_DB)
                    .With("Lightstone")
                    .With(10m)
                    .With(typeof (IProvideDataFromLightstoneAuto))
                    .Build();
            }
        }

        public static DataProvider SignioDriversLicenseDataProvider
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.LSAutoDecryptDriverLic_I_WS)
                    .With("Signio")
                    .With(10m)
                    .With(typeof (IProvideDataFromSignioDriversLicenseDecryption))
                    .Build();
            }
        }

        public static DataProvider PCubedFicaDataProvider
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.PCubedFica_E_WS)
                    .With("PCubed")
                    .With(10m)
                    .With(typeof (IProvideDataFromPCubedFicaVerfication))
                    .Build();
            }
        }

        public static DataProvider LightstoneProperty
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.LSPropertySearch_E_WS)
                    .With("LightstoneProperty")
                    .With(10m)
                    .With(typeof (IProvideDataFromLightstoneProperty))
                    .Build();
            }
        }
    }
}