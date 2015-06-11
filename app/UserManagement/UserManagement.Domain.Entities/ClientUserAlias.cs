using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.NHibernate.Attributes;

namespace UserManagement.Domain.Entities
{
    public class ClientUserAlias : Entity
    {
        public virtual string UuId { get; protected internal set; }
        public virtual string FirstName { get; protected internal set; }
        public virtual string LastName { get; protected internal set; }
        [DomainSignature]
        public virtual string UserName { get; protected internal set; }
        public virtual User User { get; set; }
        [DomainSignature]
        public virtual Client Client { get; protected internal set; }
    }
}