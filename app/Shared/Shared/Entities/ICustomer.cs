using System.Collections.Generic;

namespace DataPlatform.Shared.Entities
{
    public interface ICustomer : INamedEntity, IEntity
    {
        IEnumerable<ICustomerUser> CustomerUsers { get; }
        IEnumerable<IUser> Users { get; }
        void Add(IUser user);
        void Add(IContract contract);
    }
}