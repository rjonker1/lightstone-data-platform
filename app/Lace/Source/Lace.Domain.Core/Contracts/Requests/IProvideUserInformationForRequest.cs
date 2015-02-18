using System;

namespace Lace.Domain.Core.Contracts.Requests
{
    public interface IProvideUserInformationForRequest
    {
        Guid UserId { get; }
        string UserName { get; }
        string UserFirstName { get; }
        [Obsolete]
        string UserEmail { get; }
        [Obsolete]
        string UserLastName { get; }
        [Obsolete]
        string UserPhone { get; }
    }
}
