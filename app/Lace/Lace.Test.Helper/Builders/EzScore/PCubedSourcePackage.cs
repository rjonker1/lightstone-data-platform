using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Fakes.RequestTypes;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.EzScore
{
    public class PCubedEzScoreSourcePackage
    {
        public static IHavePackageForRequest PCubedEzScoreRequestPackage(string idNumber, string phoneNumber, string emailAddress)
        {
            return new PCubedEzScorePackage(idNumber, phoneNumber, emailAddress);
        }

        public class PCubedEzScorePackage : IHavePackageForRequest
        {
            private readonly string _idNumber;
            private readonly string _phoneNumber;
            private readonly string _emailAddress;
            public PCubedEzScorePackage(string idNumber, string phoneNumber, string emailAddress)
            {
                _idNumber = idNumber;
                _phoneNumber = phoneNumber;
                _emailAddress = emailAddress;
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
                get { return new IAmDataProvider[] { new DataProvider(DataProviderName.PCubedEzScore, 50, 27, PCubedEzScoreRequest.WithDefault(_emailAddress, _idNumber, _phoneNumber)) }; }
            }

            public string Name
            {
                get { return "PCubed Ez Score Package"; }
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
