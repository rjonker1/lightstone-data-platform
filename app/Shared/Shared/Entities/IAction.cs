namespace DataPlatform.Shared.Entities
{
    public interface IAction : INamedEntity, IEntity
    {
        ICriteria Criteria { get; }
    }
}