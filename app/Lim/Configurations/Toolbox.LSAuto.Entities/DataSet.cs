using System;

namespace Toolbox.LSAuto.Entities
{
    public class DataSet
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual long Version { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateModified { get; set; }
        public virtual bool Activated { get; set; }
    }
}