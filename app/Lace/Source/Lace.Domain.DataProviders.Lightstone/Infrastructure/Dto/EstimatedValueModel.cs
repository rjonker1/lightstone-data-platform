using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto
{
    public class EstimatedValueModel : IRespondWithEstimatedValueModel
    {
        public EstimatedValueModel(string estimatedValue, string estimatedLow, string estimatedHigh,
            string confidenceValue, string confidenceLevel)
        {
            EstimatedValue = estimatedValue;
            EstimatedLow = estimatedLow;
            EstimatedHigh = estimatedHigh;
            ConfidenceLevel = confidenceLevel;
            ConfidenceValue = confidenceValue;
        }

        public string EstimatedValue { get; private set; }

        public string EstimatedLow { get; private set; }

        public string EstimatedHigh { get; private set; }

        public string ConfidenceValue { get; private set; }

        public string ConfidenceLevel { get; private set; }
    }
}
