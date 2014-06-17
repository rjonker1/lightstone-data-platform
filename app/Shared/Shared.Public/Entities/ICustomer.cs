using System.Collections.Generic;

namespace DataPlatform.Shared.Public.Entities
{
    public interface ICustomer : INamedEntity
    {
        IEnumerable<ICustomerUser> CustomerUsers { get; }
        IEnumerable<IUser> Users { get; }
    }
}