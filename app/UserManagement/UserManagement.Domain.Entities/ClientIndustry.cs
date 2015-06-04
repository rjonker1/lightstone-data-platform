using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ClientIndustry : Entity
    {
        public virtual Client Client { get; set; }
        public virtual Guid IndustryId { get; set; }
    }
}