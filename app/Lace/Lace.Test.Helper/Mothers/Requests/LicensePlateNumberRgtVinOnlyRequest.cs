﻿using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests
{
    public class LicensePlateNumberRgtVinOnlyRequest : IPointToVehicleRequest
    {
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
            get { return new RequestContextInformation(); }
        }

        public DateTime RequestDate
        {
            get { return DateTime.Now; }
        }

        public IHavePackageForRequest Package
        {
            get { return LicensePlateNumberRgtVinRequestPackage.LicenseNumberPackage(null); } //return LicensePlateNumberRgtVinRequestPackage.LicenseNumberPackage("W0LPC6EC8DG072314");
        }

        public IHaveContract Contract
        {
            get { return new RequestContractInformation();}
        }
    }
}
