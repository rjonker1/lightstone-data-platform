namespace DataPlatform.Shared.Public.Entities
{
    public interface IContract : IExpirable
    {
        ICustomer Customer { get; set; }
    }
}