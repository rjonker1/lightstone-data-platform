using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DataPlatform.Shared.Helpers.Json;
using Newtonsoft.Json;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Domain.Entities.DataProviders.Write
{
    /// <summary>
    /// Overrides data provider values on package level
    /// </summary>
    [DataContract]
    public class DataProviderOverride : IDataProviderOverride
    {
        [DataMember]
        public Guid Id { get; internal set; }
        [DataMember]
        public double CostOfSale { get; internal set; }
        [DataMember, JsonConverter(typeof(JsonConcreteTypeConverter<IEnumerable<DataFieldOverride>>))]
        public IEnumerable<IDataFieldOverride> DataFieldOverrides { get; internal set; } 
    }
}