namespace DataPlatform.Shared.Entities
{
    public interface IUserGroup : IEntity
    {
        IUser User { get; }
        IGroup Group { get; }
    }
}