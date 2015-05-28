using System;
namespace Lim.Domain.Entities {
    
    public class PackageResponses {
        public virtual long Id { get; protected set; }
        public virtual System.Guid PackageId { get; set; }
        public virtual System.Guid Userid { get; set; }
        public virtual System.Guid ContractId { get; set; }
        public virtual int AccountNumber { get; set; }
        public virtual DateTime ResponseDate { get; set; }
        public virtual System.Guid RequestId { get; set; }
        public virtual string Payload { get; set; }
        public virtual bool HasResponse { get; set; }
        public virtual DateTime? CommitDate { get; set; }
        public virtual string Username { get; set; }
    }
}
