using Lace.Shared.DataProvider.Contracts;

namespace Lace.Shared.DataProvider.Models
{
    public class Metric : IAmCachable
    {
        public const string SelectAll = @"SELECT * FROM Metric";
        public const string CacheAllKey = "urn:Auto_Carstats:Metric";
        public Metric()
        {
            
        }

        public Metric(int metricId, string metricName, int dataTypeId, int aggregationId, int hasBand, int hasMake, int hasCarType, int hasCar, int hasYear, int hasMuncipality)
        {
            Metric_ID = metricId;
            MetricName = metricName;
            DataType_ID = dataTypeId;
            Aggregation_ID = aggregationId;
            HasBand = hasBand;
            HasMake = hasMake;
            HasCarType = hasCarType;
            HasCar = hasCar;
            HasYear = hasYear;
            HasMunicipality = hasMuncipality;
        }

        public void AddToCache(ICacheRepository repository)
        {
            repository.AddItems<Metric>(SelectAll, CacheAllKey);
        }


        public int Metric_ID { get; set; }
        public int DataType_ID { get; set; }
        public string MetricName { get; set; }
        public int Aggregation_ID { get; set; }
        public int HasBand { get; set; }
        public int HasMake { get; set; }
        public int HasCarType { get; set; }
        public int HasCar { get; set; }
        public int HasYear { get; set; }
        public int HasMunicipality { get; set; }

      
    }
}
