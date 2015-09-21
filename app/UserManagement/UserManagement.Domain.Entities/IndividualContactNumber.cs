using System;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.NHibernate.Attributes;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class IndividualContactNumber : Entity
    {
        [Unique]
        public virtual Individual Individual { get; protected internal set; }
        [Unique]
        public virtual string ContactNumber { get; protected internal set; }
        public virtual ContactNumberType ContactNumberType { get; protected internal set; }

        protected IndividualContactNumber() { }

        public IndividualContactNumber(Individual individual, string contactNumber, ContactNumberType contactNumberType, Guid id = new Guid()) : base(id)
        {
            Individual = individual;
            ContactNumber = contactNumber;
            ContactNumberType = contactNumberType;
        }
    }
}