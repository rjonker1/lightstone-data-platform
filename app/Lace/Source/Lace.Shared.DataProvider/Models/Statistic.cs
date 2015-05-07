using Lace.Shared.DataProvider.Contracts;

namespace Lace.Shared.DataProvider.Models
{
    public class Statistic // : IAmCachable
    {
        public const string SelectForCarIdMakeYear =
            @"select s.Statistics_ID AS StatisticsId, s.Metric_ID AS MetricId, s.Band_ID AS BandId, s.Make_ID AS MakeId, s.CarType_ID AS CarTypeId, s.Car_ID AS CarId, s.Year_ID AS YearId, s.SaleYear_ID AS SaleYearId, s.Municipality_ID AS MunipalityId, s.IntValue, s.FloatValue, s.MoneyValue, dbo.Car.ImageUrl, dbo.Car.CarFullName, dbo.Car.CarModel, dbo.CarType.Make_ID, dbo.CarType.CarTypeName, dbo.Car.BodyShape, dbo.Car.FuelType, dbo.Car.Market, dbo.Car.TransmissionType, dbo.Car.ImageUrlSmall, dbo.Car.ImageSource from dbo.CarType INNER JOIN dbo.Car ON dbo.CarType.CarType_ID = dbo.Car.CarType_ID RIGHT OUTER JOIN dbo.[Statistics] AS s ON dbo.Car.Car_ID = s.Car_ID  where s.Metric_ID = 4 or (s.Metric_ID = 14 and s.Car_ID = @CarId and s.Year_ID = @Year) or (s.Metric_ID = 2) or (s.Metric_ID = 3 and s.Make_ID = @MakeId) or (s.Metric_ID = 5 and s.Year_ID = @Year) or (s.Metric_ID = 6 and s.Make_ID = @MakeId) or (s.Metric_ID = 7 and s.Make_ID = @MakeId) or (s.Metric_ID in (9, 10, 11, 13, 37, 35, 36, 38) and s.Car_ID = @CarId and s.Year_ID = @Year) or (s.Metric_ID in (23, 24, 25, 26, 27, 28) and s.Car_ID = @CarId)";

        //public const string SelectAll =
        //    @"select s.Statistics_ID AS StatisticsId, s.Metric_ID AS MetricId, s.Band_ID AS BandId, s.Make_ID AS MakeId, s.CarType_ID AS CarTypeId, s.Car_ID AS CarId, s.Year_ID AS YearId, s.SaleYear_ID AS SaleYearId, s.Municipality_ID AS MunipalityId, s.IntValue, s.FloatValue, s.MoneyValue, dbo.Car.ImageUrl, dbo.Car.CarFullName, dbo.Car.CarModel, dbo.CarType.Make_ID, dbo.CarType.CarTypeName, dbo.Car.BodyShape, dbo.Car.FuelType, dbo.Car.Market, dbo.Car.TransmissionType, dbo.Car.ImageUrlSmall, dbo.Car.ImageSource from dbo.CarType INNER JOIN dbo.Car ON dbo.CarType.CarType_ID = dbo.Car.CarType_ID RIGHT OUTER JOIN dbo.[Statistics] AS s ON dbo.Car.Car_ID = s.Car_ID";

        public const string CacheStatisticsKey = "urn:Auto_Carstats:Statistics:{0}";

        //public const string CacheAllKey = "urn:Auto_Carstats:Statistics";


        public Statistic()
        {
            
        }

        public Statistic(int statisticId, int metricId, int bandId, int? makeId, int? carTypeId, int carId, int? yearId,
            int? saleYearId, int? muncipalityId, int? intValue, double? floatValue, decimal? moneyValue,
            string imageUrl,
            string carFullName, string carModel, string carTypeName, string bodyShape,
            string fuelType, string market, string transmissionType, string imageUrlSmall, string imageSource)
        {
            StatisticsId = statisticId;
            MetricId = metricId;
            BandId = bandId;
            MakeId = makeId;
            CarTypeId = carTypeId;
            CarId = carId;
            YearId = yearId;
            SaleYearId = saleYearId;
            MunipalityId = muncipalityId;
            IntValue = intValue;
            FloatValue = floatValue;
            MoneyValue = moneyValue;
            //VinYear = vinYear;
            ImageUrl = imageUrl;
            //Period = period;
            CarFullName = carFullName;
            CarModel = carModel;
            CarTypeName = carTypeName;
            //Quarter = quarter;
            BodyShape = bodyShape;
            FuelType = fuelType;
            Market = market;
            TransmissionType = transmissionType;
            ImageUrlSmall = imageUrlSmall;
            ImageSource = imageSource;
        }
        public void AddToCache(ICacheRepository repository)
        {
           // repository.AddItems<Statistic>(SelectAll, CacheAllKey);
        }

        public int StatisticsId { get; set; }
        public int MetricId { get; set; }
        public int? MakeId { get; set; }
        public int BandId { get; set; }
        public int? CarTypeId { get; set; }
        public int CarId { get; set; }
        public int? YearId { get; set; }
        public int? SaleYearId { get; set; }
        public int? MunipalityId { get; set; }
        public int? IntValue { get; set; }
        public double? FloatValue { get; set; }
        public decimal? MoneyValue { get; set; }
        //public int VinYear { get; set; }
        public string ImageUrl { get; set; }
        //public string Period { get; set; }
        public string CarFullName { get; set; }
        public string CarModel { get; set; }
        public string CarTypeName { get; set; }
        //public string Quarter { get; set; }
        public string BodyShape { get; set; }
        public string FuelType { get; set; }
        public string Market { get; set; }
        public string TransmissionType { get; set; }
        public string ImageUrlSmall { get; set; }
        public string ImageSource { get; set; }

      
    }
    


}
