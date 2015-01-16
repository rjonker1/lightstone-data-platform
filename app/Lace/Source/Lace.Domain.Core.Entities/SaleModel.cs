using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class SaleModel : IRespondWithSaleModel
    {
        public SaleModel(string salesDate, string licensingDistrict, string salesPrice)
        {
            SalesDate = salesDate;
            LicensingDistrict = licensingDistrict;
            SalesPrice = salesPrice;
        }

        [DataMember]
        public string SalesDate { get; private set; }
        [DataMember]
        public string LicensingDistrict { get; private set; }
        [DataMember]
        public string SalesPrice { get; private set; }
    }
}
