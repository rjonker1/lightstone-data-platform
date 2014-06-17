namespace DataPlatform.Shared.Public.Entities
{
    public interface ICustomerContract : IEntity, IExpirable
    {
        ICustomer Customer { get; set; }
        IContract Contract { get; set; }
    }
}