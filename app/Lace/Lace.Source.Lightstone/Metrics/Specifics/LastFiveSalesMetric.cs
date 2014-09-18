using System.Collections.Generic;
using System.Linq;
using Lace.Models.Lightstone.DataObject;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.Metrics.Specifics
{
    public class LastFiveSalesMetric : IRetrieveATypeOfMetric<SaleModel>
    {
        public List<SaleModel> MetricResult { get; private set; }
        public IEnumerable<Statistic> Statistics { get; private set; }

        private readonly IEnumerable<Sale> _sales;
        private readonly IEnumerable<Municipality> _municipalities;

        public LastFiveSalesMetric(IEnumerable<Sale> sales, IEnumerable<Municipality> municipalities)
        {
            _sales = sales;
            _municipalities = municipalities;
            MetricResult = new List<SaleModel>();
        }

        public IRetrieveATypeOfMetric<SaleModel> Get()
        {
            var result = _sales
                .OrderByDescending(o => o.SaleDateTime)
                .Take(5)
                .Select(
                    s =>
                        new SaleModel(s.SaleDateTime.ToShortDateString(), GetMuncipalityName(s.Municipality_ID),
                            s.SalePrice.ToString("C"))).ToList();

            MetricResult.AddRange(result);

            return this;
        }

        private string GetMuncipalityName(int? municipalityId)
        {
            if (!_municipalities.Any()) return string.Empty;

            var municipality = _municipalities.FirstOrDefault(w => w.Municipality_ID == municipalityId);
            return municipality != null ? municipality.MunicipalityName : string.Empty;
        }
    }
}
