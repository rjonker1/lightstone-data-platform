namespace DataPlatform.Shared.Entities
{
    public interface ICustomerUser : IEntity
    {
        ICustomer Customer { get; set; }
        IUser User { get; set; }
    }
}