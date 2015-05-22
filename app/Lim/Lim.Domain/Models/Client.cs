﻿using System;

namespace Lim.Domain.Models
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

        public Guid Id { get; set; }
        public Guid ContractId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
    }
}