using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.PCubed.EzScore.Infrastructure.Management
{
    public class TransformPCubedEzScoreResponse : ITransformResponseFromDataProvider
    {
        public bool Continue { get; private set; }
        public IProvideDataFromPCubedEzScore Result { get; private set; }

        public void Transform()
        {
            
        }
    }
}
