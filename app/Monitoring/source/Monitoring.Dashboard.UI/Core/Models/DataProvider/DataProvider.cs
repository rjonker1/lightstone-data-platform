using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Core.Models.DataProvider
{
    [DataContract]
    public class DataProvider
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double CostPrice { get; set; }

        [DataMember]
        public double RecommendedPrice { get; set; }

        [DataMember]
        public int Action { get; set; }

        [DataMember]
        public int State { get; set; }

        [DataMember]
        public int BillNoRecords { get; set; }
    }

}