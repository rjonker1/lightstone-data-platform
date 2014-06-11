using System;

namespace Shared.Public.TestHelpers.Users
{
    public interface IDefineUserIdentifier
    {
        Guid Id { get; }
    }
}