using System.Collections.Generic;
using System.Runtime.Serialization;
using DataPlatform.Shared.Helpers.Json;
using Newtonsoft.Json;

namespace PackageBuilder.Domain.Entities.DataFields.WriteModels
{
    /// <summary>
    /// Overrides data field values on package level
    /// </summary>
    [DataContract]
    public class DataFieldOverride : IDataFieldOverride
    {
        [DataMember]
        public string Name { get; internal set; }
        [DataMember]
        public string Namespace { get; set; }
        [DataMember]
        public string DisplayName { get; internal set; }
        [DataMember]
        public double CostOfSale { get; internal set; }
        [DataMember]
        public bool? IsSelected { get; internal set; }
        [DataMember]
        public int Order { get; internal set; }
        [DataMember, JsonConverter(typeof(JsonConcreteTypeConverter<IEnumerable<DataFieldOverride>>))]
        public IEnumerable<IDataFieldOverride> DataFieldOverrides { get; set; }
    }
}