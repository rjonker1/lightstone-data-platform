namespace DataPlatform.Shared.Public.Entities
{
    public interface ICustomerUser : IEntity
    {
        ICustomer Customer { get; set; }
        IUser User { get; set; }
    }
}