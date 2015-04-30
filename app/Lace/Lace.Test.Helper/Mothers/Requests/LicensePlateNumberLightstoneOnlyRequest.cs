using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests
{

    public class VinNumberLighstoneOnlyRequest : IPointToLaceRequest
    {
        public IHaveUser User
        {
            get { return new RequestUserInformation(); }
        }

        //public IHaveVehicle Vehicle
        //{
        //    get { return RequestVehicleInformation.WithVin("SB1KV58E40F039277"); }
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
            get { return VinNumberLightstoneAutoPackage.VinNumberPackage("SB1KV58E40F039277"); } //return LicensePlateNumberLightstoneAutoPackage.LicenseNumberPackage(107483,2008)
        }


        public IHaveContract Contract
        {
            get { return new RequestContractInformation(); }
        }
    }


    public class LicensePlateNumberLightstoneOnlyRequest : IPointToLaceRequest
    {
        public IHaveUser User
        {
            get { return new RequestUserInformation(); }
        }

        //public IHaveVehicle Vehicle
        //{
        //    get { return RequestVehicleInformation.WithLicensePlate("XMC167GP"); }
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
            get { return LicensePlateNumberLightstoneAutoPackage.LicenseNumberPackage(0,0); } //return LicensePlateNumberLightstoneAutoPackage.LicenseNumberPackage(107483,2008)
        } 


        public IHaveContract Contract
        {
            get { return new RequestContractInformation(); }
        }
    }
}

