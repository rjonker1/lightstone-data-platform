using System.Collections.Generic;
using System.Linq;
using Billing.Domain.Core.Entities;

namespace Billing.Domain.Entities.DemoEntities
{
    public class User : Entity
    {
        public virtual string Name { get; protected internal set; }
        public virtual string Surname { get; protected internal set; }
        public virtual IEnumerable<TransactionMocks> Transactions { get; protected internal set; }

        private bool _hasTransactions;

        public virtual bool HasTransactions
        {
            get { return Transactions.Any(); }

            set { _hasTransactions = value; }
        }

        //[DoNotMap]
        //public virtual IEnumerable<Product> Products
        //{
        //    get
        //    {
        //        return Transactions != null ? Transactions.Select(x => x.Product) : Enumerable.Empty<Product>();
        //    }
        //} 
    }
}