using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class CreateSource : Entity, INamedEntity
    {

        public virtual string Name { get; set; }
        public virtual string Value { get; set; }

        protected CreateSource() { }

        public CreateSource(Guid id, string val) : base(id)
        {
            Name = val;
            Value = val;
        }
    }
}
