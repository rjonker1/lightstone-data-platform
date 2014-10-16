using System;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public class RolePackage : IRolePackage
    {
        public RolePackage(Guid id, IPackage package, ICustomer customer, IRole role, DateTime validUntil)
        {
            Id = id;
            Package = package;
            Customer = customer;
            Role = role;
            ValidUntil = validUntil;
        }

        public Guid Id { get; private set; }
        public IPackage Package { get; set; }
        public ICustomer Customer { get; set; }
        public IRole Role { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}