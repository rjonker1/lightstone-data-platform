namespace Lace.Toolbox.Database.Views
{
    public class ValuationView
    {
        public const string SelectValuationQueries =
            @"select top 5 s.Sale_ID, s.Car_ID, ISNULL(s.Year_ID,0) AS Year_ID, s.SaleDateTime, s.IsNew, cast(s.SalePrice as decimal(18,2)) as SalePrice, s.Municipality_ID, m.MunicipalityName from Sale s join Car c on c.Car_ID = s.Car_ID join Municipality m on m.Municipality_ID = s.Municipality_ID where s.Car_ID = @CarId and s.Year_ID = @Year order by SaleDateTime desc 
select s.Statistics_ID AS StatisticsId, s.Metric_ID AS MetricId, metric.MetricName, s.Band_ID AS BandId, b.BandName, s.Make_ID AS MakeId, s.CarType_ID AS CarTypeId, s.Car_ID AS CarId, s.Year_ID AS YearId, s.SaleYear_ID AS SaleYearId, s.Municipality_ID AS MunipalityId, s.IntValue, s.FloatValue, s.MoneyValue, dbo.Car.ImageUrl, dbo.Car.CarFullName, dbo.Car.CarModel, dbo.CarType.Make_ID, dbo.CarType.CarTypeName, dbo.Car.BodyShape, dbo.Car.FuelType, dbo.Car.Market, dbo.Car.TransmissionType, dbo.Car.ImageUrlSmall, dbo.Car.ImageSource from dbo.CarType INNER JOIN dbo.Car ON dbo.CarType.CarType_ID = dbo.Car.CarType_ID  RIGHT OUTER JOIN dbo.[Statistics] AS s ON dbo.Car.Car_ID = s.Car_ID   left outer join dbo.Band as b on b.Band_ID = s.Band_ID left outer join dbo.Metric metric on metric.Metric_ID = s.Metric_ID
               where s.Metric_ID = 4 or (s.Metric_ID = 14 and s.Car_ID = @CarId and s.Year_ID = @Year) or (s.Metric_ID = 2) or (s.Metric_ID = 3 and s.Make_ID = @MakeId) or (s.Metric_ID = 5 and s.Year_ID = @Year) or (s.Metric_ID = 6 and s.Make_ID = @MakeId) or (s.Metric_ID = 7 and s.Make_ID = @MakeId) or (s.Metric_ID in (9, 10, 11, 13, 37, 35, 36, 38, 39, 40, 41,45) and s.Car_ID = @CarId and s.Year_ID = @Year) or (s.Metric_ID in (23, 24, 25, 26, 27, 28) and s.Car_ID = @CarId)";


        public ValuationView()
        {

        }
    }
}
