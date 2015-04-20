using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Monitoring.Dashboard.UI.Core.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Workflow.Lace.Domain.Aggregates;

namespace Monitoring.Dashboard.UI.Core.Models
{

    [DataContract]
    public class SerializedPayload
    {
        [DataMember]
        public byte[] Payload { get; private set; }
        [DataMember]
        public int CommitSequence { get; private set; }

        public SerializedPayload(byte[] payload, int commitSequence)
        {
            Payload = payload;
            CommitSequence = commitSequence;
        }
    }

    [Serializable]
    [DataContract]
    public class MonitoringDataProviderView
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public string SearchTerm { get; private set; }

        [DataMember]
        public string SearchType { get; private set; }

        [DataMember]
        public string Payload { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public bool HasErrors { get; private set; }

        [DataMember]
        public string Results { get; private set; }

        [DataMember]
        public string ElapsedTime { get; private set; }

        [DataMember]
        public IEnumerable<SerializedPayload> SerializedPayloads { get; private set; }

        [DataMember]
        public string JsonPayload { get; private set; }

        public MonitoringDataProviderView()
        {

        }

        public MonitoringDataProviderView(Guid id, IEnumerable<SerializedPayload> serializedPayloads, DateTime date, bool hasErrors,
            string elapsedTime, string searchType, string searchTerm)
        {
            Id = id;
            SerializedPayloads = serializedPayloads;
            Date = date;
            HasErrors = hasErrors;
            ElapsedTime = elapsedTime;
            SearchTerm = searchTerm;
            SearchType = searchType;
        }

        public MonitoringDataProviderView GetResults()
        {
            Results = ElapsedTime.JsonToObject<Results>().ElapsedTime;
            return this;
        }

        public MonitoringDataProviderView DeserializePayload()
        {
            JsonPayload = DeserializePayloads();
            return this;
        }

        private string DeserializePayloads()
        {
            if (SerializedPayloads == null)
                return string.Empty;

            var json = new StringBuilder();
           // var json = new JObject();
           
            foreach (var payload in SerializedPayloads.OrderBy(o => o.CommitSequence))
            {
                var jsonString = Encoding.UTF8.GetString(payload.Payload).Substring(1);

                
                    //.Replace(@"\",""); //.JsonToObject();
                // Regex.Replace(a, @"\\n?", "");

                jsonString = jsonString.TrimStart('[');
                jsonString = jsonString.TrimEnd(']');
                //a = a.TrimStart('{');
                //a = a.TrimEnd('}');
                //jsonString.Replace("[", "");
                //jsonString.Replace("]", "");
                //jsonString.Replace(@"\", "");
                var request = jsonString.JsonToObject<Request>();
                Debug.WriteLine(request);
                Debug.WriteLine(jsonString);
                //Regex.Replace(a, @"\s+", "");

                //var p = a.JsonToObject();
                //var p = a.JsonToObject();
                //var o = p.ObjectToJson();
                //var j = JsonExtensions.ObjectToJson(p);
                //json.Append(p.Replace(@"\",""));
                //json.Append(j);
                //json.Append(a);
                //json.Add(JObject.Parse(a.AsJsonString()));
                //json = JValue.Parse(jsonString);
                json.Append(jsonString);
            }
            Debug.WriteLine(json.ToString());
            var jsonArray = JArray.Parse(json.ToString()) as JArray;


            //JObject jasonObject = (JObject) JObject.Parse(json.ToString());
            //jasonObject.Add();

            //var jobject = string.Format("[{0}]",json.ToString()).JsonToObject();
            //var jstring = JsonExtensions.ObjectToJson(jobject);

            Debug.WriteLine("***********JSON************");
            Debug.WriteLine("\n");
            Debug.WriteLine("Serialized : {0} Length: {1}", SerializedPayloads, SerializedPayloads.Count());
            Debug.WriteLine(jsonArray.ToString(Formatting.None));
            Debug.WriteLine("\n");
            Debug.WriteLine("************END***********");
            return jsonArray.ToString(Formatting.None); // json.ToString(Formatting.None);
        }
    }
}