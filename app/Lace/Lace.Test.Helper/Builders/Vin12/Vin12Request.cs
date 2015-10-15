using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.Vin12
{
    public class Vin12Request
    {
        public static IHavePackageForRequest Vin12WithVinNumber(string vinNumber)
        {
            return new Vin12Package(vinNumber);
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
            get
            {
                return Guid.NewGuid();
            }
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
}
