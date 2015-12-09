using System;
namespace Toolbox.LSAuto.Entities
{
    public class View
    {
        public virtual long Id { get; set; }
        public virtual Guid AggregateId { get; set; }
        public virtual string Name { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual bool Activated { get; set; }
        public virtual long Version { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime? DateModified { get; set; }
        public virtual Guid? ModifiedBy { get; set; }
        public virtual Guid CreatedBy { get; set; }
    }
}
