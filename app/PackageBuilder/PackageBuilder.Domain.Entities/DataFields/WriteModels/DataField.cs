using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PackageBuilder.Core.Attributes;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.Domain.Entities.DataFields.WriteModels
{
    [DataContract]
    public class DataField : IDataField
    {
        [DataMember]
        public Guid DataProviderId { get; internal set; }
        public string Namespace { get; set; }
        [DataMember]
        public string Name { get; internal set; }
        [DataMember]
        public string Label { get; internal set; }
        [DataMember]
        public string Definition { get; internal set; }
        [DataMember]
        public IEnumerable<Industry> Industries { get; internal set; }
        [DataMember, MapToCurrentValue]
        public double CostOfSale { get; internal set; }
        [DataMember]
        public bool? IsSelected { get; internal set; }
        [DataMember]
        public Type Type { get; internal set; }
        [DataMember]
        public IEnumerable<IDataField> DataFields { get; private set; }
        
        //todo: make private
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

        public DataField(string name, string label, string definition, IEnumerable<Industry> industries, double costOfSale, bool isSelected)//, Type type)
        {
            Name = name;
            Label = label;
            Definition = definition;
            Industries = industries;
            CostOfSale = costOfSale;
            IsSelected = isSelected;
            //Type = type;
        }

        public DataField(string name, string label, string definition, IEnumerable<Industry> industries, double costOfSale, bool isSelected, IEnumerable<IDataField> dataFields)//, Type type)
        {
            Name = name;
            Label = label;
            Definition = definition;
            Industries = industries;
            CostOfSale = costOfSale;
            IsSelected = isSelected;
            DataFields = dataFields;
            //Type = type;
        }

        public void SetDataProviderId(Guid id)
        {
            DataProviderId = id;
        }

        public void SetPrice(double costPrice)
        {
            CostOfSale = costPrice;
        }
    }
}