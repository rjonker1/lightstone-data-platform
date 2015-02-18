using System;

namespace UserManagement.Domain.Dtos
{
    public class PackageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public bool IsActivated { get; set; }
    }
}