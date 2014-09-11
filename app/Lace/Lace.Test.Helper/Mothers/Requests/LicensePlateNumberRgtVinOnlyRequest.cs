using System;
using DataPlatform.Shared.Entities;
using Lace.Request;
using Lace.Test.Helper.Mothers.Requests.Dto;
using PackageBuilder.Domain.Entities;

namespace Lace.Test.Helper.Mothers.Requests
{
    public class LicensePlateNumberRgtVinOnlyRequest : ILaceRequest
    {

        public ILaceRequestUserInformation User
        {
            get
            {
                return new RequestUserInformation();
            }
        }

        public ILaceRequestContext Context
        {
            get
            {
                return new ContextInformation();
            }
        }

        public ILaceRequestVehicleInformation Vehicle
        {
            get
            {
                return new RequestVehicleInformation();
            }
        }

        public IProvideRequestAggregation RequestAggregation
        {
            get
            {
                return new AggregationInformation();
            }
        }

        public DateTime RequestDate
        {
            get
            {
                return DateTime.Now;
            }
        }

        public string SearchTerm
        {
            get
            {
                return "XMC167GP";
            }
        }

        public IPackage Package
        {
            //get
            //{
            //    return LicensePlateNumberRgtVinRequestPackage.LicenseNumberPackage();
            //}
            get { return new Package(""); }
        }

        //public ILaceRequestCarInformation CarInformation
        //{
        //    get
        //    {
        //        return new RequestCarInformationForCarHavingId107483();
        //    }
        //}
    }
}
