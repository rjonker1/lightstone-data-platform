using System;

namespace Lace.Request
{
    public interface ILaceRequestUserInformation
    {
        Guid UserId { get; }
        Guid AggregateId { get; }

        string UserName { get; }
        string UserFirstName { get; }
        string UserLastName { get; }

        string UserEmail { get; }
        string UserPhone { get; }

    }
}
