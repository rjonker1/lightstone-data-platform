using System;

namespace PackageBuilder.Domain.Entities.Packages.ReadModels
{
    public class ReadPackage
    {
        public Guid Id { get; set; }
        public Guid DataProviderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public int Version { get; set; }
    }
}
