namespace DataPlatform.Shared.Entities
{
    public interface IGroupPermission : IEntity, IExpirable
    {
        IGroup Group { get; set; }
        IAction Action { get; set; }
    }
}