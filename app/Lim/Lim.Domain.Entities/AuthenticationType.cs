namespace Lim.Domain.Entities {
    
    public class AuthenticationType {
        public virtual short Id { get; set; }
        public virtual string Type { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
