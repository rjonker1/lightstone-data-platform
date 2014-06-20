namespace DataPlatform.Shared.Entities
{
    public interface IUserRole : IEntity
    {
        IUser User { get; set; }
        IRole Role { get; set; }
    }
}