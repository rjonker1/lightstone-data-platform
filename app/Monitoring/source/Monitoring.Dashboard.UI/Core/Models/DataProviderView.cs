using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Monitoring.Dashboard.UI.Core.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
    
    [DataContract]
    public class DataProviderView
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
        public string ElapsedTime { get; private set; }

        [DataMember]
        public IEnumerable<SerializedPayload> SerializedPayloads { get; private set; }

        [DataMember]
        public string JsonPayload { get; private set; }

        public DataProviderView()
        {

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

      
        public DataProviderView DeserializePayload()
        {
            JsonPayload = DeserializePayloads();
            return this;
        }

        private string DeserializePayloads()
        {
            if (SerializedPayloads == null)
                return string.Empty;

            var jarray = new JArray();
            SerializedPayloads.OrderBy(o => o.CommitSequence)
                .ToList()
                .ForEach(f => jarray.Add(JArray.Parse(Encoding.UTF8.GetString(f.Payload).Substring(1))));

            return jarray.ToString(Formatting.None);
        }
    }
}