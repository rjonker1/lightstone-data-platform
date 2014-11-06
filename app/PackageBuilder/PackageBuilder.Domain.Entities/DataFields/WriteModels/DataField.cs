using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Entities;

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
        
        //todo: make private
        public DataField()
        {
        }

        public DataField(string name, Type type)
        {
            Name = name;
            Type = type;
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
    }
}