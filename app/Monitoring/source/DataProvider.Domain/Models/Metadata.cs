using System.Runtime.Serialization;

namespace DataProvider.Domain.Models
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