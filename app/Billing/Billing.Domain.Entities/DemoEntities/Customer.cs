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

        //Used for AutoMapper (Flatten structure for maaping)
        [DoNotMap]
        public virtual IEnumerable<Product> Products
        {
            get
            {
                var products = Users.Select(x => x.Transactions).SelectMany(y =>
                {
                    var transactionMocks = y as IList<TransactionMocks> ?? y.ToList();
                    return transactionMocks;
                }).Select(x => x.Product);

                return Users != null ? products : Enumerable.Empty<Product>();
            }
        }

        //Used for AutoMapper (Flatten structure for mapping)
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