using System;
using DataPlatform.Shared.Enums;

namespace Api.Domain.Core.Meta
{
    public class MetaPackage
    {
        public Guid PackageId { get; set; }
        public string PackageName { get; set; }
        public PackageEventType? PackageEventType { get; set; }
    }
}