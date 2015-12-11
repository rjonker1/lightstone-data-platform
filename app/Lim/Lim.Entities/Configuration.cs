using System;


namespace Lim.Entities
{
    
    public class Configuration {

        public virtual long Id { get; set; }
        public virtual Client Client  { get; set; }
        public virtual System.Guid ConfigurationKey { get; set; }
        public virtual FrequencyType FrequencyType { get; set; }
        public virtual ActionType ActionType { get; set; }
        public virtual IntegrationType IntegrationType { get; set; }
        public virtual DateTime? DateCreated { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual DateTime? DateModified { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual TimeSpan? CustomFrequencyTime { get; set; }
        public virtual string CustomFrequencyDay { get; set; }
    }
}