using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Package : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Version { get; set; }
        public virtual bool? IsActivated { get; set; }

        protected Package() { }

        public Package(string name, string version, bool? isActivated, Guid id = new Guid()) 
            : base(id)
        {

            Name = name;
            Version = version;
            IsActivated = isActivated;
        }
    }
}
