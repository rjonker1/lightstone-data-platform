using DataPlatform.Shared.Entities;
using Lace.Domain.Core.Contracts.Requests;
using System;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests
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

        public IProvideJisInformation Jis
        {
            get { return new RequestJisInformation(); }
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
