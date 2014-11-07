using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto;

namespace PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations
{
    public class AccidentDistributionBuilder
    {
        private string _band;
        private double _value;

        public IRespondWithAccidentDistributionModel Build()
        {
            return new AccidentDistributionModel(_band, _value);
        }

        public AccidentDistributionBuilder With(string band)
        {
            _band = band;
            return this;
        }

        public AccidentDistributionBuilder With(double value)
        {
            _value = value;
            return this;
        }
    }
}