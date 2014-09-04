using System;
using DataPlatform.Shared.Entities;
using Lace.Request;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests
{
    public class LicensePlateNumberIvidTitleHolderWithAbsaFinancedInterestRequest : ILaceRequest
    {
        public IPackage Package
        {
            get
            {
                return LicensePlateNumberIvidTitleHolderRequestPackage.LicenseNumberPackage();
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
                return new IvidTitleHolderRequestVehicleIWithAbsaFinancedInterestInformation();
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
                return "YXK559GP";
            }
        }

        public ILaceRequestCarInformation CarInformation
        {
            get
            {
                return new RequestCarInformationForCarHavingId107483();
            }
        }
    }
}
