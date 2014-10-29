namespace DataPlatform.Shared.Entities
{
    public interface ICustomerUser : IEntity
    {
        ICustomer Customer { get; }
        IUser User { get; }
    }
}