using System;
namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IPointToLaceRequest
    {
        DateTime RequestDate { get; }
        IHavePackageForRequest Package { get; }
        IHaveRequestContext Request { get; }
        IHaveContractInformation Contract { get; }
    }
}
