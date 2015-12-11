using System;

namespace Lim.Entities
{
    
    public class VersionInfo {
        public virtual long Version { get; set; }
        public virtual DateTime? AppliedOn { get; set; }
        public virtual string Description { get; set; }
    }
}
