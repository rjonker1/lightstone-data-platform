using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.Valuations
{
    public class EstimatedValueModelBuilder
    {
        private string _retailEstimatedValue;
        private string _retailEstimatedLow;
        private string _retailEstimatedHigh;
        private string _retailConfidenceValue;
        private string _retailConfidenceLevel;

        public IRespondWithEstimatedValueModel Build()
        {
            var model = new EstimatedValueModel();
            model.SetRetailEstimatedValues(_retailEstimatedValue, _retailEstimatedLow, _retailEstimatedHigh, _retailConfidenceValue, _retailConfidenceLevel);
            return model;
        }

        public EstimatedValueModelBuilder With(string retailEstimatedValue, string retailEstimatedLow,
            string retailEstimatedHigh,
            string retailConfidenceValue, string retailConfidenceLevel)
        {
            _retailEstimatedValue = retailEstimatedValue;
            _retailEstimatedLow = retailEstimatedLow;
            _retailEstimatedHigh = retailEstimatedHigh;
            _retailConfidenceValue = retailConfidenceValue;
            _retailConfidenceLevel = retailConfidenceLevel;
            return this;
        }
    }
}