namespace DataPlatform.Shared.Entities
{
    public interface ICustomerContract : IEntity, IExpirable
    {
        ICustomer Customer { get; }
        IContract Contract { get; }
    }
}