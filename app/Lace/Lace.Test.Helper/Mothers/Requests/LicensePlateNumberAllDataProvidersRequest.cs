using System;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Core.Requests.Contracts.Requests;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests
{

    public class LicensePlateNumberAllDataProvidersRequest : IAmLicensePlateRequest
    {
        private readonly IHaveRequestContext _aggregation;
        private readonly DateTime _requestDate;

        public LicensePlateNumberAllDataProvidersRequest()
        {
            _aggregation = new RequestContextInformation();
            _requestDate = DateTime.Now;
        }

        public IHaveUser User
        {
            get { return new RequestUserInformation(); }
        }

        public IHaveVehicle Vehicle
        {
            get { return RequestVehicleInformation.WithLicensePlate("CL49CTGP"); }
        }

        public IHaveRequestContext Request
        {
            get { return _aggregation; }
        }

        public DateTime RequestDate
        {
            get { return _requestDate; }
        }

        public IHavePackageForRequest Package
        {
            get { return LicensePlateNumberAllRequestPackage.LicenseNumberPackage("CL49CTGP", "VVi+Adx"); }
        }


        public IHaveContract Contract
        {
            get { return new RequestContractInformation(); }
        }
    }
}
