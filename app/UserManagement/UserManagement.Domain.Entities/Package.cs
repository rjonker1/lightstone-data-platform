using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Package : Entity
    {

        public virtual string LastUpdateBy { get; set; }
        public virtual DateTime LastUpdateDate { get; set; }
        public virtual string Name { get; set; }
        public virtual string Version { get; set; }
        public virtual bool? IsActivated { get; set; }


        protected Package() { }

        public Package(Guid id, string lastUpdateBy, DateTime lastUpdateDate, string name, string version, bool? isActivated) 
            : base(id)
        {

            LastUpdateBy = lastUpdateBy;
            LastUpdateDate = lastUpdateDate;
            Name = name;
            Version = version;
            IsActivated = isActivated;
        }
    }
}
