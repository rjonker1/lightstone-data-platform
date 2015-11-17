using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Fakes.RequestTypes;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.Finance
{
    public class BmwFinanceInterestsRequest
    {
        public static IHavePackageForRequest BmwFinanceRequestWithVinNumber(string vinNumber)
        {
            return new BmwFinancePackage(vinNumber, "", "", "","");
        }

        public static IHavePackageForRequest BmwFinanceRequestWithVinAndEngineNumber(string vinNumber, string engineNumber)
        {
            return new BmwFinancePackage(vinNumber, "", "", "",engineNumber);
        }

        public static IHavePackageForRequest BmwFinanceRequestWithLicenseNumber(string licenseNumber)
        {
            return new BmwFinancePackage("", "", "", licenseNumber,"");
        }

        public static IHavePackageForRequest BmwFinanceRequestWithAccountNumber(string accountNumber)
        {
            return new BmwFinancePackage("", "", accountNumber, "","");
        }

        public static IHavePackageForRequest BmwFinanceRequestWithIdNumber(string idNumber)
        {
            return new BmwFinancePackage("", idNumber, "", "","");
        }

        public class BmwFinancePackage : IHavePackageForRequest
        {
            private readonly string _vinNumber;
            private readonly string _idNumber;
            private readonly string _licenseNumber;
            private readonly string _accountNumber;
            private readonly string _engineNumber;
            public BmwFinancePackage(string vinNumber, string idNumber, string accountNumber, string licenseNumber, string engineNumber)
            {
                _vinNumber = vinNumber;
                _idNumber = idNumber;
                _accountNumber = accountNumber;
                _licenseNumber = licenseNumber;
                _engineNumber = engineNumber;
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
                        new DataProvider(DataProviderName.BMWFSTitle_E_DB, 50, 27,
                            BmwFinanceRequest.WithDefault(_vinNumber, _idNumber, _licenseNumber, _accountNumber, _engineNumber),
                            new BillableState(DataProviderNoRecordState.Billable))

                    };
                }
            }

            public string Name
            {
                get { return "Lightstone Bmw Finance Package"; }
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
}
