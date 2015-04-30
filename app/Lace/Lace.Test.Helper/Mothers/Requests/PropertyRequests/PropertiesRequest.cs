using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Builders.Property;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests.PropertyRequests
{
    public class PropertiesRequest : IPointToLaceRequest
    {
        public DateTime RequestDate
        {
            get { return DateTime.Now; }
        }

        public IHavePackageForRequest Package
        {
            get
            {
                return PropertySourcePackage.PropertyPackage(new Guid("5a7222e1-ee65-433b-b673-827319e89cbb"),
                    7902065199085, 1000, Guid.NewGuid());
            }
        }

        public IHaveRequestContext Request
        {
            get { return new RequestContextInformation(); }
        }

        public IHaveContract Contract
        {
            get { return new RequestContractInformation(); }
        }

        public IHaveUser User
        {
            get { return new RequestUserInformation(); }
        }
    }
}
