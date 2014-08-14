namespace Lace.Source.Lightstone.Models
{
    public class Statistics
    {
        public int Statistics_ID { get; set; }

        public int Metric_ID { get; set; }

        public int Band_ID { get; set; }

        public int? Make_ID { get; set; }

        public int? CarType_ID { get; set; }

        public int? Car_ID { get; set; }

        public int? Year_ID { get; set; }

        public int? SaleYear_ID { get; set; }

        public int? Municipality_ID { get; set; }

        public int? IntValue { get; set; }

        public double? FloatValue { get; set; }

        public decimal? MoneyValue { get; set; }

        //public virtual Make Make { get; set; }

        //public virtual CarType CarType { get; set; }

        //public virtual Car Car { get; set; }

        //public virtual Municipality Municipality { get; set; }

        //public virtual Metric Metric { get; set; }

        //public virtual Band Band { get; set; }

        
    }
}
