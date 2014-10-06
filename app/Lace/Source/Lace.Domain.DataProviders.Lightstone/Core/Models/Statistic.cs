namespace Lace.Domain.DataProviders.Lightstone.Core.Models
{
    public class Statistic
    {
        public Statistic()
        {
        }

        public Statistic(int statisticId, int metricId, int bandId, int? makeId, int? carTypeId, int? carId, int? yearId, int? saleYearId, int? muncipalityId, int? intValue, double? floatValue, decimal? moneyValue)
        {
            Statistics_ID = statisticId;
            Metric_ID = metricId;
            Band_ID = bandId;
            Make_ID = makeId;
            CarType_ID = carTypeId;
            Car_ID = carId;
            Year_ID = yearId;
            SaleYear_ID = saleYearId;
            Municipality_ID = muncipalityId;
            IntValue = intValue;
            FloatValue = floatValue;
            MoneyValue = moneyValue;
        }


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
