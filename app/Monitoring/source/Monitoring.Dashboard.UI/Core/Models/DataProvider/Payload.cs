using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Monitoring.Dashboard.UI.Core.Extensions;
using Newtonsoft.Json.Linq;

namespace Monitoring.Dashboard.UI.Core.Models.DataProvider
{
    [DataContract]
    public class PayloadObject
    {
        [DataMember]
        public string MetaData { get; set; }

        [DataMember]
        public string Payload { get; set; }
      
        [DataMember]
        public MetaData MetadataObject
        {
            get
            {
                return string.IsNullOrEmpty(MetaData) ? new MetaData() : MetaData.JsonToObject<MetaData>() ?? new MetaData();
            }
        }

        [DataMember]
        public List<DataProviders> DataProviders
        {
            get
            {
                var obj = string.IsNullOrEmpty(Payload) ? new Package() : Payload.TrimEnd(']').TrimStart('[').JsonToObject<dynamic>() ?? new Package();
                var dataProviders = ((JArray)obj.Package.DataProviders).Select(s => new DataProviders
                {
                    Name = (int)s["Name"],
                    DataProviderJson = ((JArray)s["Request"]).First().AsJsonString()
                });

                return dataProviders.ToList();
            }
        }
    }
  

   
}