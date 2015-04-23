using System;

namespace Lace.CrossCutting.DataProvider.Car.Infrastructure.SqlStatements
{
    public class SelectStatements
    {
         [Obsolete]
        public const string GetCarInformationById =
            @"SELECT c.Car_ID as CarId, 0 as [Year], c.ImageUrl, 'Not Available' as [Quarter],c.CarFullName, c.CarModel from Car c where Car_ID = @CarId";

        [Obsolete]
        public const string GetCarInformationByVin =
            @"SELECT v.Car_ID as CarId, v.Year_ID as [Year],c.ImageUrl, case when v.Period = 'First' then '1st Quarter' when v.Period = 'Second' then '2nd Quarter' when v.Period = 'Third' then '3rd Quarter' when v.Period = 'Fourth' then '4th Quarter' else 'Not Available' end as [Quarter], c.CarFullName, c.CarModel from Car c join Vin v on c.Car_ID = v.Car_ID where v.VIN = @Vin and c.Car_ID is not null and v.Year_ID is not null";

        public const string GetCarInformationByVin12 =
            @"SELECT DISTINCT c.Car_ID as CarId, s.Year_ID as [Year], c.ImageUrl, 'Not Available' as [Quarter],c.CarFullName,c.CarModel  from VinShort vs join Car c on c.Car_ID = vs.Car_ID join dbo.[Statistics] s on s.Car_ID = vs.Car_ID
                where  SUBSTRING(vs.VinShortName,0,12) = SUBSTRING(@Vin,0,12) and s.Year_ID is not null";
    }
}
