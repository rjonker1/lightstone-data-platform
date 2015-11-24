using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Monitoring.Dashboard.UI.Core.Enums;
using Monitoring.Dashboard.UI.Core.Extensions;
using Monitoring.Dashboard.UI.Core.Models.DataProvider.Events;
using Monitoring.Dashboard.UI.Core.Models.DataProvider.RequestFields;
using Monitoring.Dashboard.UI.Infrastructure.Factory;
using Newtonsoft.Json.Linq;

namespace Monitoring.Dashboard.UI.Domain.DataProviders
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

        public void DetermineRequestField(ExecutionBegan @event)
        {
            foreach (var dataProvider in @event.Payload.DataProviders)
            {
                var obj = !string.IsNullOrEmpty(dataProvider.DataProviderJson) ? dataProvider.DataProviderJson.JsonToObject<dynamic>() : null;
                if (obj != null)
                    _findRequestField.DetermineRequestField((JObject) obj, _requestFields);
            }

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