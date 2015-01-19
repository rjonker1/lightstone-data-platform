using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class ImageGaugeModel : IRespondWithImageGaugeModel
    {
        public ImageGaugeModel(double? minValue, double? maxValue, double? value, double? quarter, string gaugeName)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            Value = value;
            Quarter = quarter;
            GaugeName = gaugeName;
        }

        [DataMember]
        public double? MinValue
        {
            get;
            private set;
        }
        [DataMember]
        public double? MaxValue
        {
            get;
            private set;
        }
        [DataMember]
        public double? Value
        {
            get;
            private set;
        }
        [DataMember]
        public double? Quarter
        {
            get;
            private set;
        }
        [DataMember]
        public string GaugeName
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
