﻿using System;
namespace Lace.Domain.DataProviders.Lightstone.Core.Models
{
    public class Sale
    {
        private const string SelectTopFiveSalesForCarIdAndYear =
            @"SELECT TOP 5 s.* from Sale s join Car c on c.Car_ID = s.Car_ID join Municipality m on m.Municipality_ID = s.Municipality_ID where s.Car_ID = @CarId and s.Year_ID = @Year order by SaleDateTime desc";

        private const string SelectAllSales =
            @"SELECT  s.* from Sale s join Car c on c.Car_ID = s.Car_ID join Municipality m on m.Municipality_ID = s.Municipality_ID";

        public Sale()
        {
            
        }

        public Sale(int saleId, int carId, int? yearId, DateTime saleDateTime, bool isNew, decimal salePrice,
            int muncipalityId)
        {
            Sale_ID = saleId;
            Car_ID = carId;
            Year_ID = yearId;
            SaleDateTime = saleDateTime;
            IsNew = isNew;
            SalePrice = salePrice;
            Municipality_ID = muncipalityId;
        }

        public static string GetTopFiveUsingCarIdAndYear()
        {
            return SelectTopFiveSalesForCarIdAndYear;
        }

        public static string GetAllSales()
        {
            return SelectAllSales;
        }


        public int Sale_ID { get; set; }
        public int Car_ID { get; set; }
        public int? Year_ID { get; set; }
        public DateTime SaleDateTime { get; set; }
        public bool IsNew { get; set; }
        public decimal SalePrice { get; set; }
        public int Municipality_ID { get; set; }
    }
}
