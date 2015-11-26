using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataProvider.Domain.Models
{
    [DataContract]
    public class Package
    {
        [DataMember]
        public List<DataProviders> DataProviders { get; set; }
    }

    //[DataContract]
    //public class PackageContainer
    //{
    //    [DataMember]
    //    public Package Package { get; set; }
    //}
}