using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using DataProvider.Domain.Enums;
using DataProvider.Domain.Extensions;
using DataProvider.Domain.Models.RequestFields;
using DataProvider.Infrastructure.Factory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataProvider.Infrastructure
{
    public class RequestField
    {
        private readonly IFindRequestField _findRequestField;
        private readonly List<RequestFieldType> _requestFields;
        public List<RequestFieldCount> RequestFieldCounts;

        public RequestField()
        {
            _requestFields = new List<RequestFieldType>();
            RequestFieldCounts = new List<RequestFieldCount>();
            _findRequestField = new RequestFieldFinderFactory().Create();
        }

        public void DetermineRequestField(string jsonRequestFields)
        {
            var obj = !string.IsNullOrEmpty(jsonRequestFields) ? (JObject)JsonConvert.DeserializeObject(jsonRequestFields) : new JObject();
            if (obj != null) _findRequestField.DetermineRequestField((JObject)obj, _requestFields);
            RequestFieldCounts.AddRange(_requestFields.GroupBy(g => g).Select(s => new RequestFieldCount(s.Key.Description(), 1)));
            _requestFields.Clear();
        }
    }

    public class RequestFieldCount
    {
        public RequestFieldCount(string name, int count)
        {
            Name = name;
            Count = count;
        }

        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public int Count { get; private set; }
    }
}