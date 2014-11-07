using Lace.Domain.Core.Contracts.DataProviders.Metric;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto;

namespace PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations
{
    public class TotalSalesByAgeModelBuilder
    {
        private string _band;
        private IPair<string, double>[] _values;

        public IRespondWithTotalSalesByAgeModel Build()
        {
            return new TotalSalesByAgeModel(_values, _band);
        }

        public TotalSalesByAgeModelBuilder With(string band)
        {
            _band = band;
            return this;
        }

        public TotalSalesByAgeModelBuilder With(IPair<string, double>[] values)
        {
            _values = values;
            return this;
        }
    }
}