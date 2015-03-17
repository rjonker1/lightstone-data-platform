using System;
using Billing.Domain.Core.Entities;
using Billing.Domain.Entities.DemoEntities;

namespace Billing.Domain.Entities
{
    public class PreBilling : Entity
    {
        public virtual string CustomerName { get; protected internal set; }
        public virtual User NumUsers { get; protected internal set; }
        public virtual string Type { get; protected internal set; }
        public virtual string Owner { get; protected internal set; }
        public virtual Product NumProducts { get; protected internal set; }
        public virtual TransactionMocks NumTransactions { get; protected internal set; }
        public virtual string UserType { get; protected internal set; }
        public virtual int Total { get; protected internal set; }

        public PreBilling() { }

        public PreBilling(Guid id, string customerName, User numUsers, string type, string owner, Product numProducts, TransactionMocks numTransactions, string userType, int total)
            : base(id)
        {
            CustomerName = customerName;
            NumUsers = new User();
            Type = type;
            Owner = owner;
            NumProducts = numProducts;
            NumTransactions = numTransactions;
            UserType = userType;
            Total = total;
        }
    }
}