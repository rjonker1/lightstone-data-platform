using System;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class RequestContractInformation : IHaveContractInformation
    {
        public Guid ContractId
        {
            get { return new Guid("5B6DC4A1-C598-4751-8274-1AE366AC061A"); }
        }

        public long ContractVersion
        {
            get { return 1; }
        }

        public string AccountNumber
        {
            get { return "ACCRJ000000"; }
        }
    }
}
