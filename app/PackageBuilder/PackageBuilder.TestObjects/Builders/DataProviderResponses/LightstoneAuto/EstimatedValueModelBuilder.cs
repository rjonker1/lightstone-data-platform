using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneAuto
{
    public class EstimatedValueModelBuilder
    {
        private string _retailEstimatedValue;
        private string _retailEstimatedLow;
        private string _retailEstimatedHigh;
        private string _retailConfidenceValue;
        private string _retailConfidenceLevel;
        private string _tradeEstimatedValue;
        private string _tradeEstimatedLow;
        private string _tradeEstimatedHigh;
        private string _tradeConfidenceValue;
        private string _tradeConfidenceLevel;

        public IRespondWithEstimatedValueModel Build()
        {
            var model = new EstimatedValueModel();
            model.SetRetailEstimatedValues(_retailEstimatedValue, _retailEstimatedLow, _retailEstimatedHigh, _retailConfidenceValue, _retailConfidenceLevel);
            model.SetTradeEstimatedValues(_tradeEstimatedValue, _tradeEstimatedLow, _tradeEstimatedHigh, _tradeConfidenceValue, _tradeConfidenceLevel);
            return model;
        }

        public EstimatedValueModelBuilder With(string retailEstimatedValue, string retailEstimatedLow, string retailEstimatedHigh, string retailConfidenceValue, string retailConfidenceLevel,
            string tradeEstimatedValue, string tradeEstimatedLow, string tradeEstimatedHigh, string tradeConfidenceValue, string tradeConfidenceLevel)
        {
            _retailEstimatedValue = retailEstimatedValue;
            _retailEstimatedLow = retailEstimatedLow;
            _retailEstimatedHigh = retailEstimatedHigh;
            _retailConfidenceValue = retailConfidenceValue;
            _retailConfidenceLevel = retailConfidenceLevel;

            _tradeEstimatedValue = tradeEstimatedValue;
            _tradeEstimatedLow = tradeEstimatedLow;
            _tradeEstimatedHigh = tradeEstimatedHigh;
            _tradeConfidenceValue = tradeConfidenceValue;
            _tradeConfidenceLevel = tradeConfidenceLevel;

            return this;
        }
    }
}