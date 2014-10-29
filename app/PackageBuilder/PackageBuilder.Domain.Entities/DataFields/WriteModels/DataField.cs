using System;

namespace PackageBuilder.Domain.Entities.DataFields.WriteModels
{
    public class DataField : IDataField
    {
        public string Name { get; private set; }
        public string Label { get; set; }
        public string Definition { get; set; }
        public string Industries { get; set; }
        public double Price { get; set; }
        public bool? IsSelected { get; set; }
        public Type Type { get; private set; }
        
        //todo: make private
        public DataField()
        {
        }

        public DataField(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        public DataField(string name, string label, string definition, string industries, double price, bool isSelected)//, Type type)
        {
            Name = name;
            Label = label;
            Definition = definition;
            Industries = industries;
            Price = price;
            IsSelected = isSelected;
            //Type = type;
        }
    }
}