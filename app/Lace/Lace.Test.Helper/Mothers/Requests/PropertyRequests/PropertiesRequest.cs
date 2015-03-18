using System;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Test.Helper.Builders.Property;
using Lace.Test.Helper.Mothers.Requests.Dto;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;

namespace Lace.Test.Helper.Mothers.Requests.PropertyRequests
{
    public class PropertiesRequest : Domain.Core.Requests.Contracts.ILaceRequest
    {
        public IPackage Package
        {
            get
            {
                return PropertySourcePackage.PropertyPackage();
            }
        }

        public IProvidePropertyInformationForRequest Property
        {
            get
            {
                return new RequestPropertyInformation();
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

        public IProvideVehicleInformationForRequest Vehicle { get; private set; }

        public IProvideRequestAggregation RequestAggregation
        {
            get
            {
                return new AggregationInformation();
            }
        }

        public IProvideCoOrdinateInformationForRequest CoOrdinates { get; private set; }
        public IProvideJisInformation Jis { get; private set; }
        public IProvideDriversLicenseInformationForRequest DriversLicense { get; private set; }
        public IProvideFicaInformationForRequest Fica { get; private set; }
   
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
                return "";
            }
        }
    }
}
