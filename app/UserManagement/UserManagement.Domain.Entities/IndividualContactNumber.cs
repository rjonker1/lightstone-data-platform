using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class IndividualContactNumber : Entity
    {
        public virtual Individual Individual { get; protected internal set; }
        public virtual string ContactNumber { get; protected internal set; }
        public virtual ContactNumberType ContactNumberType { get; protected internal set; }
    }
}