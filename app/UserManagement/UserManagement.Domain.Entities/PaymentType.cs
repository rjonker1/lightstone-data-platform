using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class PaymentType : Entity, INamedEntity
    {

        public virtual string Name { get; set; }
        public virtual string Value { get; set; }

        protected PaymentType() { }

        public PaymentType(Guid id, string val) : base(id)
        {
            Name = val;
            Value = val;
        }
    }
}
