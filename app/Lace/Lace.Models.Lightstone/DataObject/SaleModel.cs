using Lace.Models.Responses.Sources.Specifics;

namespace Lace.Models.Lightstone.DataObject
{
    public class SaleModel : IRespondWithSaleModel
    {
        public SaleModel(string salesDate, string licensingDistrict, string salesPrice)
        {
            SalesDate = salesDate;
            LicensingDistrict = licensingDistrict;
            SalesPrice = salesPrice;
        }


        public string SalesDate { get; private set; }

        public string LicensingDistrict { get; private set; }

        public string SalesPrice { get; private set; }
    }
}
