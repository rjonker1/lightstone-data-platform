using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public interface ICustomerContract : IEntity, IExpirable
    {
        ICustomer Customer { get; }
        IContract Contract { get; }
    }
}