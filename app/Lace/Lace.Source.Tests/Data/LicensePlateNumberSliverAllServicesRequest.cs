using DataPlatform.Shared.Entities;
using Lace.Request;
using System;
using Lace.Tests.Data.PakageData;
using Lace.Tests.Data.RequestData;

namespace Lace.Source.Tests.Data
{
    public class LicensePlateNumberSliverAllServicesRequest : ILaceRequest
    {

        public IPackage Package
        {
            get
            {
                return LicensePlateNumberAllRequestPackage.LicenseNumberPackage();
            }
        }

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


        public IProvideRequestAggregation RequestAggregation
        {
            get
            {
                return  new AggregationInformation();
            }
        }
    }
}
