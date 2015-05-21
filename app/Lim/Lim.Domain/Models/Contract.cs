using System;
namespace Lim.Domain.Models
{
    public class Contract
    {
        public const string Select = @"select c.Id, c.Name, cc.ClientId from contract c join ClientContract cc on c.Id = cc.ContractId";
        //public const string Select = @"select c.Id, c.Name, cc.ClientId from contract c join ClientContract cc on c.Id = cc.ContractId where cc.ClientId = @ClientId";

        public Contract(Guid id, string name, Guid clientId)
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