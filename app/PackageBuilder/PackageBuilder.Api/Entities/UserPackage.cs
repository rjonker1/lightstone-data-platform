using System;
using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.Entities
{
    public class UserPackage : IUserPackage
    {
        public Guid Id { get; set; }
        public DateTime ValidUntil { get; set; }
        public IPackage Package { get; set; }
        public IAction Action { get; set; }
        public ICustomer Customer { get; set; }
        public IUser User { get; set; }
    }
}