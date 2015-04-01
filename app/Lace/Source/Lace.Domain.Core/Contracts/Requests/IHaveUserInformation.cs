using System;

namespace Lace.Domain.Core.Contracts.Requests
{
    public interface IHaveUserInformation
    {
        Guid UserId { get; }
        string UserName { get; }
        string UserFirstName { get; }
    }
}
