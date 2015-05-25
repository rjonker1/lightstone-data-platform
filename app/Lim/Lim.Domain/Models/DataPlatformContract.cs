using System;
namespace Lim.Domain.Models
{
    public class DataPlatformContract
    {
        //public const string Select = @"select c.Id, c.Name, cc.ClientId from contract c join ClientContract cc on c.Id = cc.ContractId";
        public const string Select = @"
select c.Id, c.Name, cc.ClientId from contract c join ClientContract cc on c.Id = cc.ContractId
union
select c.Id, c.Name, cc.CustomerId from Customer c join CustomerContract cc on c.Id = cc.ContractId";
        
        public DataPlatformContract(Guid id, string name, Guid clientId)
        {
            Id = id;
            Name = name;
            ClientId = clientId;
        }

        public Guid Id { get; private set; }
        public Guid ClientId { get; private set; }
        public string Name { get; private set; }
    }
}