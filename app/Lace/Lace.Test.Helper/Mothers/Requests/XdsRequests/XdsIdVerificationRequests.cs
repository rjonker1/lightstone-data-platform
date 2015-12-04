using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Builders.Xds;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests.XdsRequests
{
    public class XdsIdVerificationRequests : IPointToLaceRequest
    {
        public IHaveUser User
        {
            get { return new RequestUserInformation(); }
        }

        //public IHaveVehicle Vehicle
        //{
        //    get { return RequestVehicleInformation.WithLicensePlate("CL49CTGP"); }
        //}

        public IHaveRequestContext Request
        {
            get { return new RequestContextInformation(); }
        }

        public DateTime RequestDate
        {
            get { return DateTime.Now; }
        }

        public IHavePackageForRequest Package
        {
            get { return XdsIdVerficationRequest.XdsIdVerficationWithIdNumber("8310245010082"); }//  get { return LicensePlateNumberRgtRequestPackage.LicenseNumberPackage(112859); } //return LicensePlateNumberRgtRequestPackage.LicenseNumberPackage(112859);
        }


        public IHaveContract Contract
        {
            get { return new RequestContractInformation(); }
        }
    }
}
