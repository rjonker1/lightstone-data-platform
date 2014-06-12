﻿using System;
using DataPlatform.Shared.Public.Entities;
using Lace.Request;
using Lace.Test.Helper.Mothers.Packages.Dto;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests
{
    public class LicensePlateNumberIvidOnlyRequest : ILaceRequest
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

        public IProvideRequestAggregation RequestAggregation
        {
            get
            {
                return new AggregationInformation();
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



      
    }
}
