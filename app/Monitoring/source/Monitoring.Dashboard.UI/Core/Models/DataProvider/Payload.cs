using System.Collections.Generic;
using System.Runtime.Serialization;
using DataPlatform.Shared.Dtos;
using Monitoring.Dashboard.UI.Core.Extensions;

namespace Monitoring.Dashboard.UI.Core.Models.DataProvider
{
    [DataContract]
    public class Payload
    {
        [DataMember]
        public string MetaData { get; set; }
      
        [DataMember]
        public MetaData MetadataObject
        {
            get
            {
                return string.IsNullOrEmpty(MetaData) ? new MetaData() : MetaData.JsonToObject<MetaData>() ?? new MetaData();
            }
        }
    }

    [DataContract]
    public class RequestDetailsPayload
    {
        [DataMember]
        public string Payload { get; set; }

        [DataMember]
        public Package Pacakge
        {
            get
            {
                var obj = string.IsNullOrEmpty(Payload) ? new Package() : Payload.JsonToObject<Package>() ?? new Package();
                return obj;
            }
        }
        
    }

    [DataContract]
    public class Package
    {
        [DataMember]
        public List<DataProviders> DataProviders { get; set; }
    }
}