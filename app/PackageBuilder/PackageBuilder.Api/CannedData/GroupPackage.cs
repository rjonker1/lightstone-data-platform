using System;
using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.CannedData
{
    public class GroupPackage : IGroupPackage
    {
        public Guid Id { get; set; }
        public IPackage Package { get; set; }
        public IAction Action { get; set; }
        public ICustomer Customer { get; set; }
        public IGroup Group { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}