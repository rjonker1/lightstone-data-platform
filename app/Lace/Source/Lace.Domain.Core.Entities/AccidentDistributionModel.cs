using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class AccidentDistributionModel : IRespondWithAccidentDistributionModel
    {
        public AccidentDistributionModel(string band, double value)
        {
            Band = band;
            Value = value;
        }

        [DataMember]
        public string Band
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
