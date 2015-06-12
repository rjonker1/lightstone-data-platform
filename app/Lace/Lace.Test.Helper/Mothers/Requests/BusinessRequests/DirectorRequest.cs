using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Builders.Business;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests.BusinessRequests
{
    public class DirectorRequest : IPointToLaceRequest
    {
        public DateTime RequestDate
        {
            get { return DateTime.Now; }
        }

        public IHavePackageForRequest Package
        {
            get { return new DirectorPackage(7902065199085, "", ""); }
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
