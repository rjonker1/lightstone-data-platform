using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class PriceModel : IRespondWithPriceModel
    {

        public PriceModel(string name, decimal value)
        {
            Name = name;
            Value = value;
        }

        [DataMember]
        public string Name
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
        [DataMember]
        public string TypeName
        {
            get
            {
                return GetType().Name;
            }
        }
        [DataMember]
        public Type Type
        {
            get
            {
                return GetType();
            }
        }
    }
}
