using System;
using DataPlatform.Shared.Identifiers;

namespace Shared.Public.TestHelpers.Packages
{
    public interface IDefinePackageIdentifer
    {
        Guid Id { get; }
        VersionIdentifier Version { get; }
    }
}