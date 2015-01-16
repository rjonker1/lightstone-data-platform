using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class AmortisedValueModel : IRespondWithAmortisedValueModel
    {
        public AmortisedValueModel(string year, decimal value)
        {
            Year = year;
            Value = value;
        }

        [DataMember]
        public string Year
        {
            get;
            private set;
        }

        [DataMember]
        public decimal Value
        {
            get;
            private set;
        }
    }
}
