using System.Collections.Generic;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public interface ICustomer : INamedEntity, IEntity
    {
        IEnumerable<ICustomerUser> CustomerUsers { get; }
        IEnumerable<IUser> Users { get; }
        void Add(IUser user);
        void Add(IContract contract);
    }
}