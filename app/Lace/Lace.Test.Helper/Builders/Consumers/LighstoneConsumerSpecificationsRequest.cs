using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Fakes.RequestTypes;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.Consumers
{
    public class LighstoneConsumerSpecificationsRequest
    {
        public static IHavePackageForRequest LighstoneConsumerSpecificationsRequestPackage(string vinNumber, string accessKey)
        {
            return new LightstoneConsumerPackage(vinNumber, accessKey);
        }

        public class LightstoneConsumerPackage : IHavePackageForRequest
        {
            private readonly string _vinNumber;
            private readonly string _accessKey;
            public LightstoneConsumerPackage(string vinNumber, string accessKey)
            {
                _vinNumber = vinNumber;
                _accessKey = accessKey;
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
                        new DataProvider(DataProviderName.LSConsumerRepair_E_WS, 50, 27,
                            LightstoneConsumerSpecificationsRequest.WithDefault(_accessKey, _vinNumber), new BillableState(DataProviderNoRecordState.Billable))
                        
                    };
                }
            }

            public string Name
            {
                get { return "Lightstone EzScore Package"; }
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
