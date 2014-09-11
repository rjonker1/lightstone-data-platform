namespace Lace.Source.Lightstone.Models
{
    public class Metric
    {
        public Metric()
        {
            
        }

        public Metric(int metricId, string metricName, int aggregationId, int hasBand, int hasMake, int hasCarType, int hasCar, int hasYear, int hasMuncipality)
        {
            Metric_ID = metricId;
            MetricName = metricName;
            Aggregation_ID = aggregationId;
            HasBand = hasBand;
            HasMake = hasMake;
            HasCarType = hasCarType;
            HasCar = hasCar;
            HasYear = hasYear;
            HasMunicipality = hasMuncipality;
        }

        public int Metric_ID { get; set; }
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
