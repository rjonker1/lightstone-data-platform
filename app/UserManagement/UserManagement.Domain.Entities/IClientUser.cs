using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public interface IClientUser : IEntity
    {

        IUser User { get; set; }
        IClient Client { get; set; }

    }
}
