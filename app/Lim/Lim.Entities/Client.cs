using System;
using System.Collections.Generic;

namespace Lim.Entities
{
    public class Client {
        public Client() { }
        public virtual long Id { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string ContactPerson { get; set; }
        public virtual string ContactNumber { get; set; }
        public virtual DateTime? DateCreated { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? DateModified { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual IList<Configuration> Configurations { get; set; }
    }
}