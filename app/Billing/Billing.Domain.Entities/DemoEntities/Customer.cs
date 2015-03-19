using System.Collections.Generic;
using Billing.Domain.Core.Entities;

namespace Billing.Domain.Entities.DemoEntities
{
    public class Customer : NamedEntity
    {
        public virtual IEnumerable<PreBilling> InvoicePreBillings { get; protected internal set; }
        public virtual IEnumerable<User> Users { get; protected internal set; }
    }
}