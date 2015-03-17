using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DataPlatform.Shared.Helpers.Json;
using Newtonsoft.Json;
using PackageBuilder.Core.Attributes;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.Industries.Read;
using PackageBuilder.Domain.Entities.Industries.Read;

namespace PackageBuilder.Domain.Entities.DataFields.Write
{
    [DataContract]
    public class DataField : IDataField
    {
        [DataMember]
        public Guid DataProviderId { get; internal set; } //todo check if in use else remove
        public string Namespace { get; set; }
        [DataMember]
        public string Name { get; internal set; }
        [DataMember]
        public string Label { get; internal set; }
        [DataMember]
        public string Definition { get; internal set; }
        [DataMember]
        public IEnumerable<IIndustry> Industries { get; internal set; }
        [DataMember, MapToCurrentValue]
        public double CostOfSale { get; internal set; }
        [DataMember]
        public bool? IsSelected { get; internal set; }
        [DataMember]
        public int Order { get; internal set; }
        [DataMember]
        public Type Type { get; internal set; }
        [DataMember, JsonConverter(typeof(JsonConcreteTypeConverter<IEnumerable<DataField>>))]
        public IEnumerable<IDataField> DataFields { get; internal set; }

        //Default constructor for deserialization
        public DataField()
        {
        }

        public DataField(string name, Type type, IEnumerable<Industry> industries)
        {
            Name = name;
            Type = type;
			Industries = industries;
        }

        public DataField(string name, Type type, IEnumerable<IDataField> dataFields)
        {
            Name = name;
            Type = type;
            DataFields = dataFields;
        }

        public DataField(string name, string label, string definition, IEnumerable<IIndustry> industries, double costOfSale, bool isSelected)//, Type type)
        {
            Name = name;
            Label = label;
            Definition = definition;
            Industries = industries;
            CostOfSale = costOfSale;
            IsSelected = isSelected;
            //Type = type;
        }

        public DataField(string name, string label, string definition, IEnumerable<IIndustry> industries, double costOfSale, bool isSelected, int order, IEnumerable<IDataField> dataFields)//, Type type)
        {
            Name = name;
            Label = label;
            Definition = definition;
            Industries = industries;
            CostOfSale = costOfSale;
            IsSelected = isSelected;
            Order = order;
            DataFields = dataFields;
            //Type = type;
        }

        public void OverrideValuesFromPackage(double costPrice, bool? selected)
        {
            CostOfSale = costPrice;
            IsSelected = selected;
        }
    }
}