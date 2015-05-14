using System;
using System.Runtime.Serialization;

namespace Lim.Domain.Respository.Dto
{
    [DataContract]
    public class Contract
    {
        //private const string select = @"select c.Id ContractId, c.Name ContractName, cp.PackageId PackageId, cc.ClientId ClientId, cl.Name ClientName, p.Name PackageName, 0 AccountNumber from [Contract] c join ContractPackage cp on c.Id = cp.ContractId join ClientContract cc on c.Id = cc.ContractId join Client cl on cc.ClientId = cl.Id join PackageBuilder.dbo.Package p  on p.PackageId = cp.PackageId";

        public Contract()
        {
            
        }

        public Contract(Guid contractId, string contractName, int accountNumber, Guid pacakgeId, Guid clientId, string clientName, string packageName)
        {
            ContractId = contractId;
            ContractName = contractName;
            AccountNumber = accountNumber;
            PackageId = pacakgeId;
            ClientId = clientId;
            ClientName = clientName;
            PackageName = packageName;
        }


        [DataMember]
        public Guid ContractId { get; private set; }
        [DataMember]
        public string ContractName { get; private set; }
        [DataMember]
        public int AccountNumber { get; private set; }
        [DataMember]
        public Guid PackageId { get; private set; }
        [DataMember]
        public Guid ClientId { get; private set; }
        [DataMember]
        public string ClientName { get; private set; }
        [DataMember]
        public string PackageName { get; private set; }
    }
}
