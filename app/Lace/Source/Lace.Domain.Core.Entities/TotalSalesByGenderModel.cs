using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class TotalSalesByGenderModel : IRespondWithTotalSalesByGenderModel
    {
        public TotalSalesByGenderModel(string carType, string band, double value)
        {
            CarType = carType;
            Band = band;
            Value = value;
        }

        [DataMember]
        public string CarType { get; private set; }
        [DataMember]
        public string Band { get; private set; }
        [DataMember]
        public double Value { get; private set; }
    }
}
