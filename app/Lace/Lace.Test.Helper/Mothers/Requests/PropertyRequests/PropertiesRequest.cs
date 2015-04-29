using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Core.Requests.Contracts.Requests;
using Lace.Test.Helper.Builders.Property;
using Lace.Test.Helper.Mothers.Requests.Dto;
namespace Lace.Test.Helper.Mothers.Requests.PropertyRequests
{
    public class PropertiesRequest : IAmPropertyRequest
    {
        public IHaveUser User
        {
            get { return new RequestUserInformation(); }
        }

        public IHaveProperty Property
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

        public IHaveContract Contract
        {
            get { return new RequestContractInformation();}
        }
    }
}
