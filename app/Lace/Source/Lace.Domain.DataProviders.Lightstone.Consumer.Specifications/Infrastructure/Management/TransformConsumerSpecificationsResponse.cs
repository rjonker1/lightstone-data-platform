using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Lightstone.Consumer.Specifications.Infrastructure.Management
{
    public class TransformConsumerSpecificationsResponse : ITransformResponseFromDataProvider
    {
        public void Transform()
        {

        }

        public bool Continue { get; private set; }
        public IProvideDataFromLightstoneConsumerSpecifications Result { get; private set; }
    }
}
