using System;

namespace Lim.Web.UI.Models
{
    public class Client
    {
        public const string Select = @"select c.Id,cc.ContractId,c.Name,c.ClientAccountNumberId AccountNumber from Client c join ClientContract cc on c.Id = cc.ClientId";

        public Client()
        {
            
        }
        
        public Client(Guid id, string name, string accountNumber, Guid contractId)
        {
            Id = id;
            Name = name;
            AccountNumber = accountNumber;
            ContractId = contractId;
        }

        public Guid Id { get; private set; }
        public Guid ContractId { get; private set; }
        public string Name { get; private set; }
        public string AccountNumber { get; private set; }
    }
}