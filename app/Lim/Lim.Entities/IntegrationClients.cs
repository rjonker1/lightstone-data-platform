using System;
namespace Lim.Entities
{
    
    public class IntegrationClient {
        public virtual long Id { get; set; }
        public virtual Configuration Configuration { get; set; }
        public virtual System.Guid ClientCustomerId { get; set; }
        public virtual int AccountNumber { get; set; }
        public virtual DateTime? DateCreated { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual DateTime? DateModified { get; set; }
        public virtual string ModifiedBy { get; set; }
    }
}
