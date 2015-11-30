using System.Runtime.Serialization;

namespace DataProvider.Domain.Models
{
    [DataContract]
    public class DataProviders
    {
        [DataMember]
        public int Name { get; set; }

        [DataMember]
        public string DataProviderJson { get; set; }
    }

}