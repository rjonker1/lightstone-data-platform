using Toolbox.LightstoneAuto.Domain.Base;

namespace Toolbox.LightstoneAuto.Domain.Views.AutoCarStats
{
    public class VehicleSpecifcationView : IViewMarker
    {
        public const string Select = @"select * from dbo.CarType INNER JOIN dbo.Car ON dbo.CarType.CarType_ID = dbo.Car.CarType_ID  RIGHT OUTER JOIN dbo.[Statistics] AS s ON dbo.Car.Car_ID = s.Car_ID   left outer join dbo.Band as b on b.Band_ID = s.Band_ID left outer join dbo.Metric metric on metric.Metric_ID = s.Metric_ID where s.Metric_ID in (4, 14,2,3,5,6,7,9, 10, 11, 13, 37, 35, 36, 38, 39, 40, 41,45,23, 24, 25, 26, 27, 28)";
        
        public int Metric_ID { get; set; }
        public string MetricName { get; set; }
        public int Band_ID { get; set; }
        public string BandName { get; set; }
        public int Make_ID { get; set; }
        public int CarType_ID { get; set; }
        public int Car_ID { get; set; }
        public int Year_ID { get; set; }
        public int SaleYear_ID { get; set; }
        public int Municipality_ID { get; set; }
        public float? FloatValue { get; set; }
        public double? MoneyValue { get; set; }
        public decimal? ImageUrl { get; set; }
        public string CarFullName { get; set; }
        public string CarModel { get; set; }
        public string CarTypeName { get; set; }
        public string BodyShape { get; set; }
        public string FuelType { get; set; }
        public string Market { get; set; }
        public string TransmissionType { get; set; }
        public string ImageUrlSmall { get; set; }
        public string ImageSource { get; set; }
    }
}
