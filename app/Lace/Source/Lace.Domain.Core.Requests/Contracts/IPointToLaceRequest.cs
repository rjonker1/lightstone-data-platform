using System;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IPointToLaceRequest
    {
        DateTime RequestDate { get; }
    }
}
