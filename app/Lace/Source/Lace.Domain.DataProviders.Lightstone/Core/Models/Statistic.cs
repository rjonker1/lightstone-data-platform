namespace Lace.Domain.DataProviders.Lightstone.Core.Models
{
    public class Statistic
    {
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
