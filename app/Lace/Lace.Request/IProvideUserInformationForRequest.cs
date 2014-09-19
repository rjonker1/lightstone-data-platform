using System;

namespace Lace.Request
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
