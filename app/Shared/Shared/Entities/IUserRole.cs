namespace DataPlatform.Shared.Entities
{
    public interface IUserRole : IEntity
    {
        IUser User { get; }
        IRole Role { get; }
    }
}