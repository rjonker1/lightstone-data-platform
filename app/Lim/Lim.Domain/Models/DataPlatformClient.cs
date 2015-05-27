using System;

namespace Lim.Domain.Models
{
    public class DataPlatformClient
    {
        //public const string Select = @"select c.Id,cc.ContractId,c.Name,c.ClientAccountNumberId AccountNumber from Client c join ClientContract cc on c.Id = cc.ClientId";
        public const string Select =
            @"
select c.Id,cc.ContractId,c.Name,c.ClientAccountNumberId AccountNumber from Client c join ClientContract cc on c.Id = cc.ClientId
union
select  c.Id,cc.ContractId,c.Name,c.CustomerAccountNumberId AccountNumber from Customer c join CustomerContract cc on c.Id = cc.CustomerId";

        public DataPlatformClient()
        {
            
        }
        
        public DataPlatformClient(Guid id, string name, int accountNumber, Guid contractId)
        {
            Id = id;
            Name = name;
            AccountNumber = accountNumber;
            ContractId = contractId;
        }

        public Guid Id { get; set; }
        public Guid ContractId { get; set; }
        public string Name { get; set; }
        public int AccountNumber { get; set; }
    }
}