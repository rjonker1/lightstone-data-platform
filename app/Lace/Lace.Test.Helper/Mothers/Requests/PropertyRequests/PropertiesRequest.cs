using System;
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

        public IHaveRequestContext Request
        {
            get { return new RequestContextInformation(); }
        }

        public DateTime RequestDate
        {
            get { return DateTime.Now; }
        }

        public IHavePackageForRequest Package
        {
            get { return PropertySourcePackage.PropertyPackage(); }
        }

        public IHaveContractInformation Contract
        {
            get { return new RequestContractInformation();}
        }
    }
}
