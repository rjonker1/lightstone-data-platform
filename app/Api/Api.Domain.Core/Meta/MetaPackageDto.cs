using System;

namespace Api.Domain.Core.Meta
{
    public class MetaPackageDto
    {
        public Guid PackageId { get; set; }
        public string PackageName { get; set; }
        public string PackageEventType { get; set; }
    }
}