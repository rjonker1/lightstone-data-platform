namespace DataPlatform.Shared.Entities
{
    public interface IUserGroup : IEntity
    {
        IUser User { get; set; }
        IGroup Group { get; set; }
    }
}