using System;
using Lace.Domain.Core.Contracts.Caching;
namespace Lace.Shared.DataProvider.Models
{
    public class Sale : IAmCachable
    {
        public const string SelectTopFiveSalesForCarIdAndYear =
            @"select top 5 s.Sale_ID, s.Car_ID, ISNULL(s.Year_ID,0) AS Year_ID, s.SaleDateTime, s.IsNew, cast(s.SalePrice as decimal(18,2)) as SalePrice, s.Municipality_ID from Sale s join Car c on c.Car_ID = s.Car_ID join Municipality m on m.Municipality_ID = s.Municipality_ID where s.Car_ID = @CarId and s.Year_ID = @Year order by SaleDateTime desc";

        public const string SelectAllSales =
            @"select s.Sale_ID, s.Car_ID, ISNULL(s.Year_ID,0) AS Year_ID, s.SaleDateTime, s.IsNew, cast(s.SalePrice as decimal(18,2)) as SalePrice, s.Municipality_ID from Sale s join Car c on c.Car_ID = s.Car_ID join Municipality m on m.Municipality_ID = s.Municipality_ID";

        public Sale()
        {

        }

        public Sale(int saleId, int carId, int? yearId, DateTime saleDateTime, bool isNew, decimal salePrice,
            int muncipalityId)
        {
            Sale_ID = saleId;
            Car_ID = carId;
            Year_ID = yearId.HasValue ? yearId.Value : 0;
            SaleDateTime = saleDateTime;
            IsNew = isNew;
            SalePrice = salePrice;
            Municipality_ID = muncipalityId;
        }

        public void AddToCache(ICacheRepository repository)
        {
            repository.AddItemsForEach<Sale>(SelectAllSales);
        }


        public int Sale_ID { get; set; }
        public int Car_ID { get; set; }
        public int Year_ID { get; set; }
        public DateTime SaleDateTime { get; set; }
        public bool IsNew { get; set; }
        public decimal SalePrice { get; set; }
        public int Municipality_ID { get; set; }


    }
}