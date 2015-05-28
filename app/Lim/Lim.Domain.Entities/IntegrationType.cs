namespace Lim.Domain.Entities {
    
    public class IntegrationType {
        public virtual short Id { get; protected set; }
        public virtual string Type { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
