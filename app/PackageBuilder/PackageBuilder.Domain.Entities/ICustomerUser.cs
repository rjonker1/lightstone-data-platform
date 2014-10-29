
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public interface ICustomerUser : IEntity
    {
        ICustomer Customer { get; }
        IUser User { get; }
    }
}