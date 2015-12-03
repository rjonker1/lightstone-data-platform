using System;

namespace Toolbox.LSAuto.Entities
{
    public class TableColumns
    {
        public virtual Guid Id { get; set; }
        public virtual Guid TableId { get; set; }
        public virtual string Name { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateModified { get; set; }
    }
}
