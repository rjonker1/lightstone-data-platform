using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto;

namespace PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations
{
    public class EstimatedValueModelBuilder
    {
        private string _estimatedValue;
        private string _estimatedLow;
        private string _estimatedHigh;
        private string _confidenceValue;
        private string _confidenceLevel;

        public IRespondWithEstimatedValueModel Build()
        {
            return new EstimatedValueModel(_estimatedValue, _estimatedLow, _estimatedHigh, _confidenceValue, _confidenceLevel);
        }

        public EstimatedValueModelBuilder With(string estimatedValue, string estimatedLow, string estimatedHigh,
            string confidenceValue, string confidenceLevel)
        {
            _estimatedValue = estimatedValue;
            _estimatedLow = estimatedLow;
            _estimatedHigh = estimatedHigh;
            _confidenceValue = confidenceValue;
            _confidenceLevel = confidenceLevel;
            return this;
        }
    }
}