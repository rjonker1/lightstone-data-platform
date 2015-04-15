using Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public class Billing : Entity
    {
        public virtual string Customer { get; set; }
        public virtual string Client { get; set; }

        public Billing()
        {
        }

        //public Billing()
        //{
        //    Id = Guid.NewGuid();
        //    //base.Created = DateTime.UtcNow;
        //}
    }
}