using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Individual : Entity, INamedEntity
    {
        public virtual string Name { get; protected internal set; }
        public virtual string Surname { get; protected internal set; }
        public virtual string IdNumber { get; protected internal set; }
        public virtual ISet<IndividualAddress> Addresses { get; protected internal set; }
        public virtual ISet<IndividualEmail> Emails { get; protected internal set; }
        public virtual ISet<IndividualContactNumber> ContactNumbers { get; protected internal set; }

        protected Individual() { }

        public Individual(Guid id = new Guid()) : base(id)
        {
        }
    }
}