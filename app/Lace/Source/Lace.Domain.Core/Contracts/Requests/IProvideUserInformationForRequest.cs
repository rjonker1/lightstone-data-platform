using System;

namespace Lace.Domain.Core.Contracts.Requests
{
    public interface IProvideUserInformationForRequest
    {
        Guid UserId { get; }

        string UserName { get; }
        string UserFirstName { get; }
        string UserLastName { get; }

        string UserEmail { get; }
        string UserPhone { get; }

    }
}
