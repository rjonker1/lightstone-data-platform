using System;
namespace Lace.Source.Lightstone.Models
{
    public class Sale
    {

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

        public int Sale_ID { get; set; }
        public int Car_ID { get; set; }
        public int? Year_ID { get; set; }
        public DateTime SaleDateTime { get; set; }
        public bool IsNew { get; set; }
        public decimal SalePrice { get; set; }
        public int Municipality_ID { get; set; }
    }
}
