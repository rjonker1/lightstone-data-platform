using System;
using Billing.Domain.Core.Entities;

namespace Billing.Domain.Entities.DemoEntities
{
    public class User : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual int NumTransactionsUser { get; set; }

        public User()
        {
            Name = "TT";
            Surname = "QQ";
            NumTransactionsUser = 322;
        }
    }
}