using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests
{
    public class IvidFailRequest : IPointToLaceRequest
    {
        public IHavePackageForRequest Package
        {
            get
            {
                return LicensePlateNumberForceIvidToFailPackage.LicenseNumberPackage("CN62KZGP", "VVi+");
               // return null;
            }
        }

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

        public IHaveContract Contract
        {
            get { return new RequestContractInformation(); }
        }
    }

    public class LicensePlateNumberIvidOnlyRequest : IPointToLaceRequest
    {
        public IHavePackageForRequest Package
        {
            get
            {
               // return LicensePlateNumberIvidSourcePackage.LicenseNumberPackage("CL49CTGP", "VVi+");
                return LicensePlateNumberIvidSourcePackage.LicenseNumberPackage("CN62KZGP", "VVi+");
            }
        }

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

        public IHaveContract Contract
        {
            get { return new RequestContractInformation(); }
        }
    }

    public class VinNumberIvidOnlyRequest : IPointToLaceRequest
    {
        public IHavePackageForRequest Package
        {
            get
            {
                return VinNumberIvidSourcePackage.VinNumberPackage("3C4PDCKG7DT526617", "VVi+");
            }
        }

        public IHaveUser User
        {
            get { return new RequestUserInformation(); }
        }

        public IHaveRequestContext Request
        {
            get { return new RequestContextInformation(); }
        }

        public DateTime RequestDate
        {
            get { return DateTime.Now; }
        }

        public IHaveContract Contract
        {
            get { return new RequestContractInformation(); }
        }
    }

    public class RegisterNumberIvidOnlyRequest : IPointToLaceRequest
    {
        public IHavePackageForRequest Package
        {
            get
            {
                return RegisterNumberIvidSourcePackage.RegisterNumberPackage("RWS183W", "VVi+");
            }
        }

        public IHaveUser User
        {
            get { return new RequestUserInformation(); }
        }

        public IHaveRequestContext Request
        {
            get { return new RequestContextInformation(); }
        }

        public DateTime RequestDate
        {
            get { return DateTime.Now; }
        }

        public IHaveContract Contract
        {
            get { return new RequestContractInformation(); }
        }
    }

    public class LicensePlateNumberIvidMisMatchRequest : IPointToLaceRequest
    {

        //samples
//        Request     Response
//        2SNAZI4GP   BP48JXGP    
//        yxn332gp    DZD309FS    
//        HJF622MP    HHS608EC    
//        Bz24tggp    ND509499    
        public IHavePackageForRequest Package
        {
            get
            {
                return LicensePlateNumberIvidSourcePackage.LicenseNumberPackage("VRK544GP", "VVi+");
            }
        }

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

        public IHaveContract Contract
        {
            get { return new RequestContractInformation(); }
        }
    }
}
