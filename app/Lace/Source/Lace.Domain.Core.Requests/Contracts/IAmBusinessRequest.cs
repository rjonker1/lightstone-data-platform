using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IAmBusinessRequest : IPointToLaceRequest
    {
        IProvideUserInformationForRequest User { get; }
        IProvideBusinessInformationForRequest Business { get; }
        IProvideRequestAggregation Aggregation { get; }
        IPackage Package { get; }
    }
}
