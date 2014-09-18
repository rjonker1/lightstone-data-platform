using Lace.Models.Responses.Sources.Metric;
using Lace.Models.Responses.Sources.Specifics;

namespace Lace.Models.Lightstone.DataObject
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
