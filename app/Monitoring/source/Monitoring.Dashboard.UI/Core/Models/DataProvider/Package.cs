using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Monitoring.Dashboard.UI.Core.Models.DataProvider
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