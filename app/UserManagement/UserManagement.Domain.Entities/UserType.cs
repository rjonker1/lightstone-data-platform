using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{

    public class UserType : Entity, IUserType
    {
        //Required for NamedEntity Comparison
        public virtual string Name { get; set; }

        public virtual string Value { get; set; }

        protected UserType() { }

        public UserType(Guid _id, string val)
        {
            Id = _id;
            Name = val;
            Value = val;
        }

        //public override string ToString()
        //{
        //    return string.Format("User type {0} - {1}", Id, Name);
        //}
    }
}
