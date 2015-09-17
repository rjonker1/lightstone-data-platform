using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class IndividualEmail : Entity
    {
        public virtual Individual Individual { get; protected internal set; }
        public virtual string Email { get; protected internal set; }
    }
}