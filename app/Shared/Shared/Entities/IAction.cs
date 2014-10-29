namespace DataPlatform.Shared.Entities
{
    public interface IAction : INamedEntity
    {
        ICriteria Criteria { get; }
    }
}