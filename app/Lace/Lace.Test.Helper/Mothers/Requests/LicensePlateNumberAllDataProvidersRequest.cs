using System;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests
{

    public class LicensePlateNumberAllDataProvidersRequest : IAmLicensePlateRequest
    {
        private readonly IHaveAggregation _aggregation;
        private readonly DateTime _requestDate;

        public LicensePlateNumberAllDataProvidersRequest()
        {
            _aggregation = new AggregationInformation();
            _requestDate = DateTime.Now;
        }

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
            get { return _aggregation; }
        }

        public DateTime RequestDate
        {
            get { return _requestDate; }
        }

        public IAmPackageForRequest Package
        {
            get { return LicensePlateNumberAllRequestPackage.LicenseNumberPackage(); }
        }
    }
}
