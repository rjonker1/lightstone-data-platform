using System;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.NHibernate.Attributes;

namespace UserManagement.Domain.Entities
{
    public class IndividualEmail : Entity
    {
        [Unique]
        public virtual Individual Individual { get; protected internal set; }
        [Unique]
        public virtual string Email { get; protected internal set; }

        protected IndividualEmail() { }

        public IndividualEmail(Individual individual, string email, Guid id = new Guid()) : base(id)
        {
            Individual = individual;
            Email = email;
        }
    }
}