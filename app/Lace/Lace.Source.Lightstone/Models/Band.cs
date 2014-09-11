namespace Lace.Source.Lightstone.Models
{
    public class Band
    {
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

        public int Band_ID { get; set; }
        public string BandName { get; set; }
        public int Metric_ID { get; set; }
        public int OrderBy { get; set; }
    }
}
