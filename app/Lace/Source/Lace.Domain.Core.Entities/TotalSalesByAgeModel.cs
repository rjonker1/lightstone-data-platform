using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Metric;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class TotalSalesByAgeModel : IRespondWithTotalSalesByAgeModel
    {
        public TotalSalesByAgeModel()
        {
            Values = new IPair<string, double>[] {};
        }

        public TotalSalesByAgeModel(IPair<string, double>[] values, string band)
        {
            Values = values;
            Band = band;
        }

        [DataMember]
        public string Band
        {
            get;
            private set;
        }
        [DataMember]
        public IPair<string, double>[] Values
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
