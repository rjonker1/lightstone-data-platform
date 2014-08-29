namespace DataPlatform.Shared.Entities
{
    public interface INamedEntity : IEntity
    {
        string Name { get; }
    }
}