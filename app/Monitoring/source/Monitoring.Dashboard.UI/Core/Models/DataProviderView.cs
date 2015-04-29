using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Common.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Monitoring.Dashboard.UI.Core.Models
{

    [DataContract]
    public class DataProviderView
    {
        private readonly ILog _log;

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
        public string ElapsedTime { get; private set; }

        [DataMember]
        public string State { get; private set; }

        [DataMember]
        public IEnumerable<SerializedPayload> SerializedPayloads { get; private set; }

        [DataMember]
        public string JsonPayload { get; private set; }

        public DataProviderView()
        {
            _log = LogManager.GetLogger(GetType());
        }

        public DataProviderView(Guid id, IEnumerable<SerializedPayload> serializedPayloads, DateTime date,
            bool hasErrors,
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

        public DataProviderView SetState(int errorCount)
        {
            State = errorCount > 0 ? "Failure" : "Successful";
            HasErrors = errorCount > 0;
            return this;
        }

        public DataProviderView DeserializePayload()
        {
            JsonPayload = DeserializePayloads();
            return this;
        }

        private string DeserializePayloads()
        {
            if (SerializedPayloads == null)
                return string.Empty;

            try
            {
                var jarray = new JArray();
                SerializedPayloads.OrderBy(o => o.CommitSequence)
                    .ToList()
                    .ForEach(f => jarray.Add(JArray.Parse("[" + Encoding.UTF8.GetString(f.Payload) + "]")));
              
                return DersializeNestedPayload(jarray.ToString(Formatting.None));
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occurred deserializing the data provider payload {0}", ex.Message);
            }

            return string.Empty;
        }

        private static string DersializeNestedPayload(string json)
        {
            var payloads = new JArray();

            var array = JArray.Parse(json);
            foreach (var payload in array)
            {
                if (payload is JArray)
                {
                    foreach (var nested in payload)
                    {
                        dynamic request = JsonConvert.DeserializeObject(nested.ToString(Formatting.None));
                        UpdateNestedPayload(request);
                        UpdateNestedMetaData(request);
                        payloads.Add(JArray.Parse(string.Format("[{0}]", request.ToString())));
                    }
                }
                else
                {
                    dynamic request = JsonConvert.DeserializeObject(payload.ToString(Formatting.None));
                    UpdateNestedPayload(request);
                    UpdateNestedMetaData(request);
                    payloads.Add(JArray.Parse(string.Format("[{0}]", request.ToString())));
                }
            }

            return payloads.ToString(Formatting.None);
        }

        private static void UpdateNestedPayload(dynamic request)
        {
            if (request.Payload == null || request.Payload.Payload == null || !IsJson(request.Payload.Payload.ToString()))
                return;


            var token = JToken.Parse(request.Payload.Payload.ToString());
            if (token is JArray)
            {
                var payload = JArray.Parse(request.Payload.Payload.ToString());
                request.Payload.Payload = payload;
            }
            else
            {
                var payload = JObject.Parse(request.Payload.Payload.ToString());
                request.Payload.Payload = payload;
            }
        }

        private static void UpdateNestedMetaData(dynamic request)
        {
            if (request.Payload == null || request.Payload.MetaData == null || !IsJson(request.Payload.Payload.ToString()))
                return;

            var token = JToken.Parse(request.Payload.MetaData.ToString());
            if (token is JArray)
            {
                var metaData = JArray.Parse(request.Payload.MetaData.ToString());
                request.Payload.MetaData = metaData;
            }
            else
            {
                var metaData = JObject.Parse(request.Payload.MetaData.ToString());
                request.Payload.MetaData = metaData;
            }
        }

        private static bool IsJson(string json)
        {
            json = json.Trim();
            return json.StartsWith("{") && json.EndsWith("}")
                   || json.StartsWith("[") && json.EndsWith("]");
        }
    }

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
}