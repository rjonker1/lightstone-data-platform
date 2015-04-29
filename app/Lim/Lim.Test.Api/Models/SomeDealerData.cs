using System.Runtime.Serialization;

namespace Lim.Test.Api.Models
{
    [DataContract]
    public class SomeDealerData
    {
        [DataMember]
        public string DealerName { get; set; }

        [DataMember]
        public string DealerUser { get; set; }
    }
}