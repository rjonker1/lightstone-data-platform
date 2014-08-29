namespace DataPlatform.Shared.Entities
{
    public interface IGroupPermission : IEntity, IExpirable
    {
        IGroup Group { get; }
        IAction Action { get; }
    }
}