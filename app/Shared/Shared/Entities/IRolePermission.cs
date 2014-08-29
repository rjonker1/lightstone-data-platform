namespace DataPlatform.Shared.Entities
{
    public interface IRolePermission : IEntity, IExpirable
    {
        IRole Role { get; }
        IAction Action { get; }
    }
}