using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class ConfidenceModel : IRespondWithConfidenceModel
    {

        public ConfidenceModel(string carType, int year, double value)
        {
            CarType = carType;
            Year = year;
            Value = value;
        }

        [DataMember]
        public string CarType
        {
            get;
            private set;
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

        public string TypeName
        {
            get
            {
                return GetType().Name;
            }
        }
        public Type Type
        {
            get
            {
                return GetType();
            }
        }
    }
}
