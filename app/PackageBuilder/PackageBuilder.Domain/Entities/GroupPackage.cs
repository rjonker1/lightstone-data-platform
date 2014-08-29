using System;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.Domain.Contracts.Enitities;

namespace PackageBuilder.Domain.Entities
{
    public class GroupPackage : IGroupPackage
    {
        public GroupPackage(Guid id, IPackage package, ICustomer customer, IGroup @group, DateTime validUntil)
        {
            Id = id;
            Package = package;
            Customer = customer;
            Group = @group;
            ValidUntil = validUntil;
        }

        public Guid Id { get; private set; }
        public IPackage Package { get; set; }
        public ICustomer Customer { get; set; }
        public IGroup Group { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}