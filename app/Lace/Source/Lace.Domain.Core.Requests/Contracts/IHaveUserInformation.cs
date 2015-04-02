using System;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IHaveUserInformation
    {
        Guid UserId { get; }
        string UserName { get; }
        string UserFirstName { get; }
    }
}
