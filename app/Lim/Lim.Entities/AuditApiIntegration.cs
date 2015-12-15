using System;
namespace Lim.Entities
{
    public class AuditApiIntegration {
        public virtual long Id { get; protected set; }
        public virtual long ClientId { get; set; }
        public virtual long ConfigurationId { get; set; }
        public virtual short ActionType { get; set; }
        public virtual short IntegrationType { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual bool WasSuccessful { get; set; }
        public virtual string Address { get; set; }
        public virtual string Suffix { get; set; }
        public virtual string Payload { get; set; }
    }
}
