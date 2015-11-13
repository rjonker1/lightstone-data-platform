namespace DataPlatform.Shared.Entities
{
    public interface IContract : INamedEntity, IEntity
    {
        ICustomer Customer { get; }
    }
}