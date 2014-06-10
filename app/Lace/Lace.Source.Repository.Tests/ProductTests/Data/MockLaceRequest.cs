using System;
using DataPlatform.Shared.Public.Entities;
using Lace.Request;
using Lace.Tests.Data.PakageData;
using Lace.Tests.Data.RequestData;

namespace Lace.Source.Repository.Tests.ProductTests.Data
{
    public class MockLaceRequest : ILaceRequest
    {

        public IPackage Package
        {
            get { return LicensePlateNumberSourcePackage.LicenseNumberPackage(); }
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
                return new AggregationInformation();
            }
        }
    }
}
