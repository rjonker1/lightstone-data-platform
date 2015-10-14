using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Fakes.RequestTypes;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.Property
{
    public class PropertySourcePackage
    {
        public static IHavePackageForRequest PropertyPackage(Guid userid, long idNumber, int maxRowsToReturn, Guid trackingNumber)
        {

            return new PropertyPackage(userid,idNumber,maxRowsToReturn,trackingNumber);
        }
    }

    public class PropertyPackage : IHavePackageForRequest
    {
        private readonly Guid _userid;
        private readonly long _idNumber;
        private readonly int _maxrows;
        private readonly Guid _trackingNumber;

        public PropertyPackage(Guid userid, long idNumber, int maxRowsToReturn, Guid trackingNumber)
        {
            _userid = userid;
            _idNumber = idNumber;
            _maxrows = maxRowsToReturn;
            _trackingNumber = trackingNumber;
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
            get { return new IAmDataProvider[] { new DataProvider(DataProviderName.LSPropertySearch_E_WS, 19, 38, LighstonePropertyRequest.WithDefault(_idNumber, _maxrows, _trackingNumber, _userid), new BillableState(DataProviderNoRecordState.Billable)) }; }
        }

        public string Name
        {
            get { return "Property Package"; }
        }

        public double PackageCostPrice
        {
            get { return 0.0; }
        }

        public double PackageRecommendedPrice
        {
            get { return 0.0; }
        }

        //public string Action
        //{
        //    get { return "Property Search"; }
        //}
    }
}
