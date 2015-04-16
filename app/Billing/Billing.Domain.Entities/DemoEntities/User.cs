using System.Collections.Generic;
using System.Linq;
using Billing.Domain.Core.Entities;

namespace Billing.Domain.Entities.DemoEntities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual IEnumerable<Transaction> Transactions { get; set; }

        //private bool _hasTransactions;
        public bool HasTransactions { get; set; }

        //public virtual bool HasTransactions
        //{
        //    get { return Transactions.Any(); }

        //    set { _hasTransactions = value; }
        //}

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