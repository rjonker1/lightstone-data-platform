using System;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IHavePackageForRequest
    {
        Guid Id { get; }
        long Version { get; }
        IAmDataProvider[] DataProviders { get; }
        string Name { get; }
       // string Action { get; }
    }
}
