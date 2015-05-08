using System;
using Lace.Shared.DataProvider.Contracts;

namespace Lace.Shared.DataProvider.Models
{
    public class Sale : IAmCachable
    {
        public const string SelectTopFiveSalesForCarIdAndYear =
            @"SELECT TOP 5 s.* from Sale s join Car c on c.Car_ID = s.Car_ID join Municipality m on m.Municipality_ID = s.Municipality_ID where s.Car_ID = @CarId and s.Year_ID = @Year order by SaleDateTime desc";

        public const string SelectAllSales =
            @"SELECT s.* from Sale s join Car c on c.Car_ID = s.Car_ID join Municipality m on m.Municipality_ID = s.Municipality_ID";

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

        public void AddToCache(ICacheRepository repository)
        {
            repository.AddItems<Sale>(SelectAllSales);
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