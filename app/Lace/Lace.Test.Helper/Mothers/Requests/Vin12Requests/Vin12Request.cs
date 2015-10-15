using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests.Vin12Requests
{
    public class Vin12Request : IPointToLaceRequest
    {
        public DateTime RequestDate
        {
            get { return DateTime.Now; }
        }

        public IHavePackageForRequest Package
        {
            get { return Lace.Test.Helper.Builders.Vin12.Vin12Request.Vin12WithVinNumber("TRUZZZ8P2B10"); }
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
