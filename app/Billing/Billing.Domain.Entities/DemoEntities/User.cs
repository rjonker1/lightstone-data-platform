using System;
using System.Collections.Generic;
using Billing.Domain.Core.Entities;

namespace Billing.Domain.Entities.DemoEntities
{
    public class User : Entity
    {
        public virtual string Name { get; protected internal set; }
        public virtual string Surname { get; protected internal set; }
        public virtual IEnumerable<TransactionMocks> Transactions { get; protected internal set; }

        //public User()
        //{
        //    Name = "TT";
        //    Surname = "QQ";
        //    NumTransactionsUser = 322;
        //}
    }
}