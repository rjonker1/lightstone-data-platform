using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class CustomerIndustry : Entity
    {
        public virtual Customer Customer { get; set; }
        public virtual Guid IndustryId { get; set; }
    }
}