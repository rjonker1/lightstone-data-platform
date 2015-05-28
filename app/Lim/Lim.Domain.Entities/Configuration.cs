using System;


namespace Lim.Domain.Entities {
    
    public class Configuration {

        public virtual long Id { get; set; }
        public virtual Client Client  { get; set; }
        public virtual System.Guid ConfigurationKey { get; set; }
        public virtual short FrequencyType { get; set; }
        public virtual short ActionType { get; set; }
        public virtual short IntegrationType { get; set; }
        public virtual DateTime? DateCreated { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual DateTime? DateModified { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual TimeSpan? CustomFrequencyTime { get; set; }
        public virtual string CustomFrequencyDay { get; set; }

        //public virtual IList<IntegrationClients> Integrationclients { get; set; }
        //public virtual IList<IntegrationContracts> IntegrationContracts { get; set; }
        //public virtual IList<IntegrationPackages> IntegrationPackages { get; set; }
    }
}
