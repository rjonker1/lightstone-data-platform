using System;

namespace Lace.Domain.Core.Contracts.Requests
{
    public interface IPointToLaceProvider
    {
        // DO NOT REMOVE - important for serialization
        Type Type { get; }
        string TypeName { get; }
    }
}
