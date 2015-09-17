using System;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class IndividualContactNumber : Entity
    {
        public virtual Individual Individual { get; protected internal set; }
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