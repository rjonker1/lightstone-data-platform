using System;
using DataPlatform.Shared.Public.Entities;
using Lace.Request;
using Lace.Tests.Data.PakageData.IvidTitleHolder;
using Lace.Tests.Data.RequestData;

namespace Lace.Source.Tests.Data
{
    public class LicensePlateNumberIvidTitleHolderOnlyRequest : ILaceRequest
    {
        public IPackage Package
        {
            get
            {
                return LicensePlateNumberIvidTitleHolderRequestPackage.LicesenNumberPackage();
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
                return new IvidTitleHolderRequestVehicleInformation();
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
    }
}
