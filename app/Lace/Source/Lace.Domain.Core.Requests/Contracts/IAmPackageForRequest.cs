using System;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IAmPackageForRequest
    {
        Guid Id { get; }
        long Version { get; }
        DataProviderName[] DataProviders { get; }
        string Name { get; }
        string Action { get; }
    }
}
