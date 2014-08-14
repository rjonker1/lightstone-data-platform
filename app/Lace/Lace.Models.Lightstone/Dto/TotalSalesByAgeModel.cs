using System.Collections.Generic;
using Lace.Models.Lightstone.Dto.Metric;

namespace Lace.Models.Lightstone.Dto
{
    public class TotalSalesByAgeModel : IRespondWithTotalSalesByAgeModel
    {
        public TotalSalesByAgeModel()
        {
            Values = new List<Pair<string, double>>();
        }

        public TotalSalesByAgeModel(List<Pair<string, double>> values, string band)
        {
            Values = values;
            Band = band;
        }

        public string Band
        {
            get;
            private set;
        }

        public List<Pair<string, double>> Values
        {
            get;
            private set;
        }
    }
}
