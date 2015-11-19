using System;

namespace UserManagement.Domain.Entities
{
    public class CustomerIndustry : Entity
    {
        public virtual Customer Customer { get; protected internal set; }
        public virtual Guid IndustryId { get; protected internal set; }

        protected CustomerIndustry()
        {
        }

        public CustomerIndustry(Customer customer, Guid industryId)
        {
            Id = Guid.NewGuid();
            Customer = customer;
            IndustryId = industryId;
        }
    }
}