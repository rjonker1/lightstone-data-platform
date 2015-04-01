using System;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests
{
    public class LicensePlateNumberLightstoneOnlyRequest : IAmLicensePlateRequest
    {
        public IHaveUserInformation User
        {
            get { return new RequestUserInformation(); }
        }

        public IHaveVehicle Vehicle
        {
            get { return new RequestVehicleInformation(); }
        }

        public IHaveAggregation Aggregation
        {
            get { return new AggregationInformation(); }
        }

        public DateTime RequestDate
        {
            get { return DateTime.Now; }
        }

        public IAmPackageForRequest Package
        {
            get { return LicensePlateNumberLightstoneSourcePackage.LicenseNumberPackage(); }
        }
    }
}

