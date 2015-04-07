using System;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IHaveUser
    {
        Guid UserId { get; }
        string UserName { get; }
        string UserFirstName { get; }
    }
}
