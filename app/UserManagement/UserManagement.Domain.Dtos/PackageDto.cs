using System;

namespace UserManagement.Domain.Dtos
{
    public class PackageDto
    {
        public virtual Guid Id { get; set; }
        public virtual Guid PackageId { get; set; }
        public virtual string Name { get; set; }
    }
}