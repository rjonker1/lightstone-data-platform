using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class RepairIndexModel : IRespondWithRepairIndexModel
    {
        public RepairIndexModel(int year, string band, double value)
        {
            Year = year;
            Band = band;
            Value = value;
        }

        [DataMember]
        public int Year
        {
            get;
            private set;
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
    }
}
