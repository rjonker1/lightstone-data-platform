using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public interface IUserGroup : IEntity
    {
        IUser User { get; }
        IGroup Group { get; }
    }
}