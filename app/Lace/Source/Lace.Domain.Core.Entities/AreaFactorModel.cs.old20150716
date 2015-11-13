using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class AreaFactorModel : IRespondWithAreaFactorModel
    {
        public AreaFactorModel(string muncipality, double value)
        {
            Municipality = muncipality;
            Value = value;
        }

        [DataMember]
        public string Municipality
        {
            get;
            private set;
        }
        [DataMember]
        public int Index
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
