using System;
namespace Lim.Dtos
{
    public class PackageDto
    {
        public PackageDto(Guid id, Guid packageId, string name, bool isActive)
        {
            Id = id;
            PackageId = packageId;
            Name = name;
            IsActive = isActive;
        }

        public Guid Id { get; set; }
        public Guid PackageId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}