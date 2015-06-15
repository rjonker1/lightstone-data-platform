using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ContractBundle : Entity
    {
        public virtual Guid Id { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int TransactionLimit { get; set; }
    }
}