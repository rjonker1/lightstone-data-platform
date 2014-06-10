using System;
using Shared.Public.TestHelpers.Systems;

namespace Shared.Public.TestHelpers.Requests
{
    public interface IDefineRequestIdentifier
    {
        Guid Id { get; }
        SystemIdentifierBuilder SystemIdentifier { get; }
    }
}