using Lace.Shared.DataProvider.Contracts;

namespace Lace.Shared.DataProvider.Models
{
    public class Band : IAmCachable
    {
        public const string SelectAll = @"SELECT * FROM Band";
        public const string CacheAllKey = "urn:Auto_Carstats:Bands";
        public Band()
        {

        }

        public Band(int bandId, string bandName, int metricId, int orderBy)
        {
            Band_ID = bandId;
            BandName = bandName;
            Metric_ID = metricId;
            OrderBy = orderBy;
        }

        public void AddToCache(ICacheRepository repository)
        {
            repository.AddItems<Band>(SelectAll, CacheAllKey);
        }

        public int Band_ID { get; set; }
        public string BandName { get; set; }
        public int Metric_ID { get; set; }
        public int OrderBy { get; set; }
        
       

        
    }
}
