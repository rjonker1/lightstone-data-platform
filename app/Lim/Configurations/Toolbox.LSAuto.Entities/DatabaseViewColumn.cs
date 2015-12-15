using System;

namespace Toolbox.LSAuto.Entities
{
    public class DatabaseViewColumn
    {
        public virtual long Id { get; set; }
        public virtual DatabaseView DatabaseView { get; set; }
        public virtual string Name { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime? DateModified { get; set; }
    }
}
