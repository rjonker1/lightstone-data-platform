using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto;

namespace PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations
{
    public class RepairIndexModelBuilder
    {
        private int _year;
        private string _band;
        private double _value;

        public IRespondWithRepairIndexModel Build()
        {
            return new RepairIndexModel(_year, _band, _value);
        }

        public RepairIndexModelBuilder With(int year)
        {
            _year = year;
            return this;
        }

        public RepairIndexModelBuilder With(string band)
        {
            _band = band;
            return this;
        }

        public RepairIndexModelBuilder With(double value)
        {
            _value = value;
            return this;
        }
    }
}