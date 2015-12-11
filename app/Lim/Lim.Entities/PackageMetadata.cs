using System;
namespace Lim.Entities
{
    public class PackageMetadata
    {
        public virtual long Id { get; set; }
        public virtual byte[] Payload { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? DateUpdated { get; set; }
        public virtual DateTime DateCreated { get; set; }
    }
}
