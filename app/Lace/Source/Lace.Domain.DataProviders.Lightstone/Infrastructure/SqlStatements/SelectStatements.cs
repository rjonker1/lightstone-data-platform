namespace Lace.Domain.DataProviders.Lightstone.Infrastructure.SqlStatements
{
    public class SelectStatements
    {
        public const string GetStatistics = @"SELECT s.* FROM dbo.[Statistics] as s
					 where s.Metric_ID = 4 
					 or (s.Metric_ID = 14 and s.Car_ID = @CarId and s.Year_ID = @YearId) 
					 or (s.Metric_ID = 2)
					 or (s.Metric_ID = 3 and s.Make_ID = @MakeId)
					 or (s.Metric_ID = 5 and s.Year_ID = @YearId)
					 or (s.Metric_ID = 6 and s.Make_ID = @MakeId)
					 or (s.Metric_ID = 7 and s.Make_ID = @MakeId)
					 or (s.Metric_ID in (9, 10, 11, 13, 37, 35, 36, 38) and s.Car_ID = @CarId and s.Year_ID = @YearId)
					 or (s.Metric_ID in (23, 24, 25, 26, 27, 28) and s.Car_ID = @CarId)";

        public const string GetAllCarVendors =
            @"SELECT DISTINCT c.Car_ID, m.MakeName, ct.CarTypeName, stat.SaleYear_ID, case when stat.SaleYear_ID is not null then ((stat.SaleYear_ID * 100000000000) + c.Car_ID) else c.Car_ID end as CarModelId,
                                             c.CarModel,c.ImageUrlSmall, c.CarFullName from Car c join CarType ct on c.CarType_ID = ct.CarType_ID join Make m on ct.Make_ID = m.Make_ID join dbo.[Statistics] stat on c.Car_ID = stat.Car_ID 
                                             where stat.Metric_ID = 16 order by m.MakeName asc, ct.CarTypeName asc, stat.SaleYear_ID desc, c.CarModel";

        public const string GetAllTheBands = @"SELECT * FROM Band";

        public const string GetAllTheMakes = @"SELECT * FROM Make";

        public const string GetAllTheMetricTypes = @"SELECT * FROM Metric";

        public const string GetAllTheMuncipalities = @"SELECT * FROM Municipality";

        public const string GetCarTypesByMake = @"SELECT * from CarType where Make_ID = @MakeId";

        public const string GetCarById =
            @"SELECT c.Car_ID, 0 as [Year], c.ImageUrl, c.CarFullName, c.CarModel from Car c where Car_ID = @CarId";

        public const string GetCarByVin =
          @"SELECT v.Car_ID, v.Year_ID, c.ImageUrl, v.Period, c.CarFullName, c.CarModel from Car c join Vin v on c.Car_ID = v.Car_ID where v.VIN = @Vin and c.Car_ID is not null and v.Year_ID is not null";

        public const string GetStatisticsByMake =
            @"SELECT s.* from dbo.[Statistics] s join Metric m on s.Metric_ID = m.Metric_ID where m.Metric_ID in (@Metrics) and s.Make_ID = @MakeId";

        public const string GetTopFiveSalesForCarIdAndYear =
            @"SELECT TOP 5 s.* from Sale s join Car c on c.Car_ID = s.Car_ID join Municipality m on m.Municipality_ID = s.Municipality_ID where s.Car_ID = @CarId and s.Year_ID = @YearId order by SaleDateTime desc";
    }
}
