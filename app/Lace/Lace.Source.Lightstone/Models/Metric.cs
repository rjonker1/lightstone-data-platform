namespace Lace.Source.Lightstone.Models
{
    public class Metric
    {
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
