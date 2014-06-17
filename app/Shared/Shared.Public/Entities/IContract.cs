namespace DataPlatform.Shared.Public.Entities
{
    public interface IContract : INamedEntity
    {
        ICustomer Customer { get; set; }
    }
}