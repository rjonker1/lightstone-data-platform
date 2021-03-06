﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DataPlatform.Shared.Helpers.Extensions;
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
        /// <summary>
        /// NB: Namespace should always be calculated at runtime
        /// </summary>
        [JsonIgnore] 
        public string Namespace { get; set; }
        [DataMember]
        public string Name { get; internal set; }
        [DataMember]
        public string Label { get; internal set; }
        [DataMember]
        public string Value { get; internal set; }
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
        public string Type { get; internal set; }
        [DataMember, JsonConverter(typeof(JsonConcreteTypeConverter<IEnumerable<DataField>>))]
        public IEnumerable<IDataField> DataFields { get; set; }

        //Default constructor for deserialization
        public DataField()
        {
        }

        public DataField(string name, string type, IEnumerable<Industry> industries, string value = "")
        {
            Name = name;
            Type = type;
			Industries = industries;
            Value = value;
        }

        public DataField(string name, string type, IEnumerable<IDataField> dataFields)
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

        public void SetName(string name)
        {
            Name = name;
        }

        //todo populate via AutoMapper in LaceResponseMap.cs
        public void SetValue(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return "{0} - {1}".FormatWith(GetType().FullName, Name);
        }
    }
}