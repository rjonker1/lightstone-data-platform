using System;

namespace Lim.Entities
{
    
    public class ConfigurationApi {
        public virtual long Id { get; set; }
        public virtual Configuration Configuration { get; set; }
        public virtual string BaseAddress { get; set; }
        public virtual string Suffix { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual bool HasAuthentication { get; set; }
        public virtual string AuthenticationToken { get; set; }
        public virtual string AuthenticationKey { get; set; }
        public virtual AuthenticationType AuthenticationType { get; set; }
        public virtual DateTime? DateCreated { get; set; }
    }
}
