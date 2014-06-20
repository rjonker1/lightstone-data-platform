using System.Collections.Generic;

namespace DataPlatform.Shared.Entities
{
    public interface ICustomer : INamedEntity
    {
        IEnumerable<ICustomerUser> CustomerUsers { get; }
        IEnumerable<IUser> Users { get; }
    }
}