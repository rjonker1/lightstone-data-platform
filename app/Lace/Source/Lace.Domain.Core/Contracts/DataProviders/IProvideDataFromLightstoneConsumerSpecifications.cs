using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromLightstoneConsumerSpecifications : IPointToLaceProvider
    {
        IAmLightstoneConsumerSpecificationsRequest Request { get; }
    }
}
