using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public interface IUserRole : IEntity
    {

        IUser User { get; set; }
        IRole Role { get; set; }

    }
}
