using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Fakes.RequestTypes;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.Xds
{
    public class XdsIdVerficationRequest
    {
        public static IHavePackageForRequest XdsIdVerficationWithIdNumber(string idNumber)
        {
            return new XdsVerficationPackage(idNumber);
        }

        public class XdsVerficationPackage : IHavePackageForRequest
        {
            
            private readonly string _idNumber;
            private readonly string _surname;
            private readonly string _firstName;
            public XdsVerficationPackage(string idNumber)
            {
                _idNumber = idNumber;
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
                        new DataProvider(DataProviderName.XDSVerifyID_E_WS, 50, 27,XdsIdVerificationRequest.WithIdNumber(_idNumber),new BillableState(DataProviderNoRecordState.Billable))

                    };
                }
            }

            public string Name
            {
                get { return "XDS ID Verification Package"; }
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
