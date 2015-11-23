using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Core.Models.DataProvider
{
    [DataContract]public class RequestField
    {
        public VinNumberRequestField VinNumber { get; set; }
        public LicenseNumberRequestField LicenceNumber { get; set; }
    }

    [DataContract]
    public class VinNumberRequestField
    {
        public string Field { get;set; }
    }

    [DataContract]
    public class LicenseNumberRequestField
    {
        public string Field { get; set; }
    }
}