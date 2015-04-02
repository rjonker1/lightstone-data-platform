﻿using System;
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
            get { return LicensePlateNumberLightstoneSourcePackage.LicenseNumberPackage(); }
        }


        public IHaveContractInformation Contract
        {
            get { return new RequestContractInformation(); }
        }
    }
}

