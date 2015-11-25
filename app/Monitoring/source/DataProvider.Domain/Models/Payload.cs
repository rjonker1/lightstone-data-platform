using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using DataProvider.Domain.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataProvider.Domain.Models
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
               // var obj = string.IsNullOrEmpty(Payload) ? new Package() : Payload.TrimEnd(']').TrimStart('[').JsonToObject<dynamic>() ?? new Package();
                var obj = string.IsNullOrEmpty(Payload) ? new JObject() : (JObject)JsonConvert.DeserializeObject(Payload.TrimEnd(']').TrimStart('['));
                var dataProviders = ((JArray)((JObject)obj.GetValue("Package")).GetValue("DataProviders")).Select(s => new DataProviders
                {
                    Name = (int)s["Name"],
                    DataProviderJson = JsonConvert.SerializeObject(s["Request"].First)
                });
                
                //var dataProviders = ((JArray)obj.GetValue("Package").First().DataProviders).Select(s => new DataProviders
                //{
                //    Name = (int)s["Name"],
                //    DataProviderJson = ((JArray)s["Request"]).First().AsJsonString()
                //});
                //var dataProviders = ((JArray)obj.Package.DataProviders).Select(s => new DataProviders
                //{
                //    Name = (int)s["Name"],
                //    DataProviderJson = ((JArray)s["Request"]).First().AsJsonString()
                //});

                return dataProviders.ToList();
            }
        }
    }
  

   
}