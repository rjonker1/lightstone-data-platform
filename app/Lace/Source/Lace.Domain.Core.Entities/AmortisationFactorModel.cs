using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class AmortisationFactorModel : IRespondWithAmortisationFactorModel
    {
        public AmortisationFactorModel(int year, double value)
        {
            Year = year;
            Value = value;
        }

        [DataMember]
        public int Year
        {
            get;
            private set;
        }
        [DataMember]
        public double Value
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
