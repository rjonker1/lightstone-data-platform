using System;
using DataPlatform.Shared.Entities;
using Lace.Request;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests
{
    public class LicensePlateNumberIvidOnlyRequest : ILaceRequest
    {

        public IPackage Package
        {
            get
            {
                return LicensePlateNumberIvidSourcePackage.LicenseNumberPackage();
            }
        }

        public IProvideUserInformationForRequest User
        {
            get
            {
                return new RequestUserInformation();
            }
        }

        public IProvideContextForRequest Context
        {
            get
            {
                return new ContextInformation();
            }
        }

        public IProvideRequestAggregation RequestAggregation
        {
            get
            {
                return new AggregationInformation();
            }
        }

        public IProvideVehicleInformationForRequest Vehicle
        {
            get
            {
                return new RequestVehicleInformation();
            }
        }

        public IProvideCoOrdinateInformationForRequest CoOrdinates
        {
            get { return new CoOrdinateInformation(); }
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

        //public ILaceRequestCarInformation CarInformation
        //{
        //    get
        //    {
        //        return new RequestCarInformationForCarHavingId107483();
        //    }
        //}
      
    }
}
