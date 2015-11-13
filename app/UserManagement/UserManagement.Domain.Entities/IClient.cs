using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public interface IClient : IEntity
    {

        IEnumerable<IClientUser> ClientUsers { get; } 

    }
}
