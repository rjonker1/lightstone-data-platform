using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Fakes.RequestTypes;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.Vin12
{
    public class Vin12Request
    {
        public static IHavePackageForRequest Vin12WithVinNumber(string vinNumber)
        {
            return new Vin12Package(vinNumber);
        }

        public static IHavePackageForRequest LightstoneAutoWithVin12VinNumber(string vinNumber)
        {
            return new LightstoneAutoVin12Package(vinNumber);
        }

        public static IHavePackageForRequest RgtVinWithVin12VinNumber(string vinNumber)
        {
            return new RgtVin12Package(vinNumber);
        }

        public static IHavePackageForRequest LightstoneAutoWithVin12LicensePlate(string licnsePlate, string packageName)
        {
            return new LightstoneAutoLicensePlateVin12Package(licnsePlate, packageName);
        }

        public static IHavePackageForRequest LightstoneAutoAndRgtVinWithVin12VinNumber(string vinNumber)
        {
            return new LightstoneAutoAndRgtVin12Package(vinNumber);
        }

    }

    public class Vin12Package : IHavePackageForRequest
    {
        private readonly string _vinNumber;

        public Vin12Package(string vinNumber)
        {
            _vinNumber = vinNumber;
        }

        public Guid Id
        {
            get { return Guid.NewGuid(); }
        }

        public long Version
        {
            get { return 1; }
        }

        public IAmDataProvider[] DataProviders
        {
            get
            {
                return new IAmDataProvider[]
                {
                    new DataProvider(DataProviderName.LSAutoVIN12_I_DB, 50, 27,
                        Lace.Test.Helper.Fakes.RequestTypes.Vin12Request.WithVinNumber(_vinNumber),
                        new BillableState(DataProviderNoRecordState.NonBillable))

                };
            }
        }

        public string Name
        {
            get { return "VIN 12 Package"; }
        }

        public double PackageCostPrice
        {
            get { return 0.0; }
        }

        public double PackageRecommendedPrice
        {
            get { return 0.0; }
        }
    }

    public class LightstoneAutoVin12Package : IHavePackageForRequest
    {
        private readonly string _vinNumber;

        public LightstoneAutoVin12Package(string vinNumber)
        {
            _vinNumber = vinNumber;
        }

        public Guid Id
        {
            get { return Guid.NewGuid(); }
        }

        public long Version
        {
            get { return 1; }
        }

        public IAmDataProvider[] DataProviders
        {
            get
            {
                return new IAmDataProvider[]
                {
                    new DataProvider(DataProviderName.LSAutoVIN12_I_DB, 50, 27,
                        Fakes.RequestTypes.Vin12Request.WithVinNumber(_vinNumber),
                        new BillableState(DataProviderNoRecordState.NonBillable)),
                    new DataProvider(DataProviderName.LSAutoCarStats_I_DB, 90, 92,
                        LightstoneAutoRequest.WithVin(_vinNumber), new BillableState(DataProviderNoRecordState.NonBillable))

                };
            }
        }

        public string Name
        {
            get { return "Lightstone Auto VIN 12 Package"; }
        }

        public double PackageCostPrice
        {
            get { return 0.0; }
        }

        public double PackageRecommendedPrice
        {
            get { return 0.0; }
        }
    }

    public class LightstoneAutoAndRgtVin12Package : IHavePackageForRequest
    {
        private readonly string _vinNumber;

        public LightstoneAutoAndRgtVin12Package(string vinNumber)
        {
            _vinNumber = vinNumber;
        }

        public Guid Id
        {
            get { return Guid.NewGuid(); }
        }

        public long Version
        {
            get { return 1; }
        }

        public IAmDataProvider[] DataProviders
        {
            get
            {
                return new IAmDataProvider[]
                {
                    new DataProvider(DataProviderName.LSAutoVIN12_I_DB, 50, 27,
                        Fakes.RequestTypes.Vin12Request.WithVinNumber(_vinNumber),
                        new BillableState(DataProviderNoRecordState.NonBillable)),
                    new DataProvider(DataProviderName.LSAutoVINMaster_I_DB, 90, 92,
                        RgtVinRequest.WithVin(_vinNumber), new BillableState(DataProviderNoRecordState.NonBillable)),
                    new DataProvider(DataProviderName.LSAutoCarStats_I_DB, 90, 92,
                        LightstoneAutoRequest.WithVin(_vinNumber), new BillableState(DataProviderNoRecordState.NonBillable))

                };
            }
        }

        public string Name
        {
            get { return "Lightstone Auto VIN 12 Package"; }
        }

        public double PackageCostPrice
        {
            get { return 0.0; }
        }

        public double PackageRecommendedPrice
        {
            get { return 0.0; }
        }
    }

    public class RgtVin12Package : IHavePackageForRequest
    {
        private readonly string _vinNumber;

        public RgtVin12Package(string vinNumber)
        {
            _vinNumber = vinNumber;
        }

        public Guid Id
        {
            get { return Guid.NewGuid(); }
        }

        public long Version
        {
            get { return 1; }
        }

        public IAmDataProvider[] DataProviders
        {
            get
            {
                return new IAmDataProvider[]
                {
                    new DataProvider(DataProviderName.LSAutoVIN12_I_DB, 50, 27,
                        Fakes.RequestTypes.Vin12Request.WithVinNumber(_vinNumber),
                        new BillableState(DataProviderNoRecordState.NonBillable)),
                    new DataProvider(DataProviderName.LSAutoVINMaster_I_DB, 90, 92,
                        RgtVinRequest.WithVin(_vinNumber), new BillableState(DataProviderNoRecordState.NonBillable))

                };
            }
        }

        public string Name
        {
            get { return "RTG Vin 12 Package"; }
        }

        public double PackageCostPrice
        {
            get { return 0.0; }
        }

        public double PackageRecommendedPrice
        {
            get { return 0.0; }
        }
    }

    public class LightstoneAutoLicensePlateVin12Package : IHavePackageForRequest
    {
        private readonly string _licesePlateNumber;
        private readonly string _packageName;

        public LightstoneAutoLicensePlateVin12Package(string licesePlateNumber, string packageName)
        {
            _licesePlateNumber = licesePlateNumber;
            _packageName = packageName;
        }

        public Guid Id
        {
            get { return Guid.NewGuid(); }
        }

        public long Version
        {
            get { return 1; }
        }

        public IAmDataProvider[] DataProviders
        {
            get
            {
                return new IAmDataProvider[]
                {
                    new DataProvider(DataProviderName.IVIDVerify_E_WS, 50, 27,
                        new IvidStandardRequest(_licesePlateNumber, "Murray", _packageName,
                            "murrayw@lightstone.co.za", "Murray", string.Empty),
                        new BillableState(DataProviderNoRecordState.NonBillable)),
                    new DataProvider(DataProviderName.LSAutoVIN12_I_DB, 50, 27,
                        Fakes.RequestTypes.Vin12Request.Empty(),
                        new BillableState(DataProviderNoRecordState.NonBillable)),
                    new DataProvider(DataProviderName.LSAutoCarStats_I_DB, 90, 92,
                        LightstoneAutoRequest.Empty(), new BillableState(DataProviderNoRecordState.NonBillable))

                };
            }
        }

        public string Name
        {
            get { return "Lightstone Auto VIN 12 Package"; }
        }

        public double PackageCostPrice
        {
            get { return 0.0; }
        }

        public double PackageRecommendedPrice
        {
            get { return 0.0; }
        }
    }
}