using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests
{
    public class LicensePlateNumberIvidTitleHolderWithAbsaFinancedInterestRequest : IPointToLaceRequest
    {
        public IHaveUser User
        {
            get { return new RequestUserInformation(); }
        }

        //public IHaveVehicle Vehicle
        //{
        //    get
        //    {
        //        return IvidTitleHolderRequestVehicleIWithAbsaFinancedInterestInformation.WithLicensePlate("NRB891W");
        //    }
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
            get { return LicensePlateNumberIvidTitleHolderRequestPackage.LicenseNumberPackage(null); }
        }


        public IHaveContract Contract
        {
            get { return new RequestContractInformation(); }
        }
    }
}
