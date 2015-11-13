using System.Collections.Generic;
using System.Runtime.Serialization;
using DataPlatform.Shared.Helpers.Json;
using Newtonsoft.Json;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;

namespace PackageBuilder.Domain.Entities.DataFields.Write
{
    /// <summary>
    /// Overrides data field values on package level
    /// </summary>
    [DataContract]
    public class DataFieldOverride : IDataFieldOverride
    {
        [DataMember]
        public string Name { get; internal set; }
        /// <summary>
        /// NB: Namespace should always be calculated at runtime
        /// </summary>
        [JsonIgnore] 
        public string Namespace { get; set; }
        [DataMember]
        public string DisplayName { get; internal set; }
        [DataMember]
        public double CostOfSale { get; internal set; }
        [DataMember]
        public bool? IsSelected { get; internal set; }
        [DataMember]
        public string Type { get; internal set; }
        [DataMember]
        public int Order { get; internal set; }
        [DataMember, JsonConverter(typeof(JsonConcreteTypeConverter<IEnumerable<DataFieldOverride>>))]
        public IEnumerable<IDataFieldOverride> RequestFieldOverrides { get; set; }
        [DataMember, JsonConverter(typeof(JsonConcreteTypeConverter<IEnumerable<DataFieldOverride>>))]
        public IEnumerable<IDataFieldOverride> DataFieldOverrides { get; set; }
    }
}