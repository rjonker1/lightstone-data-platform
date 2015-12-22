using System;
using System.Collections.Generic;

namespace Toolbox.LSAuto.Entities
{
    public class DatabaseExtract
    {
        public virtual long Id { get; set; }
        public virtual DatabaseView View { get; set; }
        public virtual Guid AggregateId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual long Version { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateModified { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual bool Activated { get; set; }
        public virtual IList<DatabaseExtractField> Fields { get; set; } 
    }
}