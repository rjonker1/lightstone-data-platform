using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Core.Models.DataProvider
{
    [DataContract]
    public class MetaData
    {
        public MetaData()
        {

        }

        [DataMember]
        public Results Results { get; set; }
    }
}