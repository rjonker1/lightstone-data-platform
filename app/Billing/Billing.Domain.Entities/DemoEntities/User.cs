using System;
using System.Collections.Generic;
using System.Linq;
using Billing.Domain.Core.Entities;
using Billing.Domain.Core.NHibernate.Attributes;

namespace Billing.Domain.Entities.DemoEntities
{
    public class User : Entity
    {
        public virtual string Name { get; protected internal set; }
        public virtual string Surname { get; protected internal set; }
        public virtual IEnumerable<TransactionMocks> Transactions { get; protected internal set; }

        [DoNotMap]
        public virtual IEnumerable<Product> Products
        {
            get
            {
                return Transactions != null ? Transactions.Select(x => x.Product) : Enumerable.Empty<Product>();
            }
        } 

        //public User()
        //{
        //    Name = "TT";
        //    Surname = "QQ";
        //    NumTransactionsUser = 322;
        //}
    }
}