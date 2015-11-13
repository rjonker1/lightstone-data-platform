using System;

namespace Workflow.Billing.Domain.Entities
{
    public class Client : AccountMeta
    {
        public virtual Guid ClientId { get; set; }
        public virtual string ClientName { get; set; }

        public Client()
        {
        }
    }
}