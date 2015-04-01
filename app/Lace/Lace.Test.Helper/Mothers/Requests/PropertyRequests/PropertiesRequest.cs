using System;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Builders.Property;
using Lace.Test.Helper.Mothers.Requests.Dto;
namespace Lace.Test.Helper.Mothers.Requests.PropertyRequests
{
    public class PropertiesRequest : IAmPropertyRequest
    {
        public IHaveUserInformation User
        {
            get { return new RequestUserInformation(); }
        }

        public IHavePropertyInformation Property
        {
            get { return new RequestPropertyInformation(); }
        }

        public IHaveAggregation Aggregation
        {
            get { return new AggregationInformation(); }
        }

        public DateTime RequestDate
        {
            get { return DateTime.Now; }
        }

        public IAmPackageForRequest Package
        {
            get { return PropertySourcePackage.PropertyPackage(); }
        }
      
    }
}
