using Lace.Domain.Core.Contracts.DataProviders.Metric;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto
{
    public class TotalSalesByAgeModel : IRespondWithTotalSalesByAgeModel
    {
        public TotalSalesByAgeModel()
        {
            Values = new IPair<string, double>[] {};
        }

        public TotalSalesByAgeModel(IPair<string, double>[] values, string band)
        {
            Values = values;
            Band = band;
        }

        public string Band
        {
            get;
            private set;
        }

        public IPair<string, double>[] Values
        {
            get;
            private set;
        }
    }
}
