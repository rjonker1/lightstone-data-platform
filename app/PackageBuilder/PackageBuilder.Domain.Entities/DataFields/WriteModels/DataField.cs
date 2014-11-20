using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PackageBuilder.Domain.Entities.DataFields.WriteModels
{
    [DataContract]
    public class DataField : IDataField
    {
        [DataMember]
        public string Name { get; internal set; }
        [DataMember]
        public string Label { get; internal set; }
        [DataMember]
        public string Definition { get; internal set; }
        [DataMember]
        public string Industry { get; internal set; }
        [DataMember]
        public double Price { get; internal set; }
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

        public DataField(string name, Type type, string industry)
        {
            Name = name;
            Type = type;
			Industry = industry;
        }

        public DataField(string name, Type type, IEnumerable<IDataField> dataFields)
        {
            Name = name;
            Type = type;
            DataFields = dataFields;
        }

        public DataField(string name, string label, string definition, string industry, double price, bool isSelected)//, Type type)
        {
            Name = name;
            Label = label;
            Definition = definition;
            Industry = industry;
            Price = price;
            IsSelected = isSelected;
            //Type = type;
        }

        public DataField(string name, string label, string definition, string industry, double price, bool isSelected, IEnumerable<IDataField> dataFields)//, Type type)
        {
            Name = name;
            Label = label;
            Definition = definition;
            Industry = industry;
            Price = price;
            IsSelected = isSelected;
            DataFields = dataFields;
            //Type = type;
        }
    }
}