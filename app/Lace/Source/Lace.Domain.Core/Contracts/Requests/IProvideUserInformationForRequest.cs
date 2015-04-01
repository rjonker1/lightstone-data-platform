using System;

namespace Lace.Domain.Core.Contracts.Requests
{
    public interface IProvideUserInformationForRequest
    {
        Guid UserId { get; }
        string UserName { get; }
        string UserFirstName { get; }
    }
}
