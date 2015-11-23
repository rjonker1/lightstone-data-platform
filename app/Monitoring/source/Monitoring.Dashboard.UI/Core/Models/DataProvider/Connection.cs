using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Core.Models.DataProvider
{
    [DataContract]
    public class ConnectionPayload
    {
        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Connection { get; set; }
    }
}