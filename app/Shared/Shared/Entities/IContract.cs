namespace DataPlatform.Shared.Entities
{
    public interface IContract : INamedEntity
    {
        ICustomer Customer { get; }
    }
}