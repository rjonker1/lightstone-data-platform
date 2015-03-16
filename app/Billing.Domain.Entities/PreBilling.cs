using System;
using Billing.Domain.Core.Entities;

namespace Billing.Domain.Entities
{
    public class PreBilling : Entity
    {
        public virtual string CustomerName { get; protected internal set; }
        public virtual string NumUsers { get; protected internal set; }
        public virtual string Type { get; protected internal set; }
        public virtual string Owner { get; protected internal set; }
        public virtual int NumProducts { get; protected internal set; }
        public virtual int NumTransactions { get; protected internal set; }
        public virtual string UserType { get; protected internal set; }
        public virtual int Total { get; protected internal set; }

        public PreBilling() { }

        public PreBilling(Guid id, string customerName, string numUsers, string type, string owner, int numProducts, int numTransactions, string userType, int total)
            : base(id)
        {
            CustomerName = customerName;
            NumUsers = numUsers;
            Type = type;
            Owner = owner;
            NumProducts = numProducts;
            NumTransactions = numTransactions;
            UserType = userType;
            Total = total;
        }
    }
}