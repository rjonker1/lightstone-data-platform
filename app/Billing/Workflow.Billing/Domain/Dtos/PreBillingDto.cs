using System.Collections.Generic;
using Shared.Messaging.Billing.Helpers;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Domain.Dtos
{
    public class PreBillingDto //: Entity
    {

        public virtual string CustomerName { get; set; }
        public virtual IEnumerable<UserMeta> Users { get; set; }
        //public IEnumerable<Transaction> Transactions { get; set; }

        public PreBillingDto() { }

        public PreBillingDto(IEnumerable<UserMeta> users)//, IEnumerable<Transaction> transactions)
        {
            Users = users;
            //Transactions = transactions;
        }
    }
}
