using System.Collections.Generic;
using System.Linq;
using Billing.Domain.Core.Entities;
using Billing.Domain.Core.NHibernate.Attributes;

namespace Billing.Domain.Entities.DemoEntities
{
    public class Customer : NamedEntity
    {
        public virtual IEnumerable<PreBilling> InvoicePreBillings { get; protected internal set; }
        public virtual IEnumerable<User> Users { get; protected internal set; }

        [DoNotMap]
        public virtual IEnumerable<Product> Products
        {
            get
            {
                return Users != null ? Users.SelectMany(x => x.Products) : Enumerable.Empty<Product>();
            }
        }

        [DoNotMap]
        public virtual IEnumerable<TransactionMocks> Transactions
        {
            get
            {
                return Users != null ? Users.SelectMany(x => x.Transactions) : Enumerable.Empty<TransactionMocks>();
            }
        } 
    }
}