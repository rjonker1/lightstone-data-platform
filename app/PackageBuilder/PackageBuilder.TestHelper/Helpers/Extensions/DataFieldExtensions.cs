using System;
using System.Collections.Generic;
using System.Linq;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Enums.Requests;
using Xunit.Extensions;

namespace PackageBuilder.TestHelper.Helpers.Extensions
{
    public static class DataFieldExtensions
    {
        public static IDataField Get(this IEnumerable<IDataField> dataFields, string name)
        {
            return dataFields.FirstOrDefault(x => x.Name == name);
        }

        public static void AssertRequestField(string name, RequestFieldType type, IEnumerable<IDataField> requestFields)
        {
            var field = requestFields.Get(name);
            field.ShouldNotBeNull();

            //todo: check type
            //field.Type.ShouldEqual(((int)type).ToString());
        }

        public static IDataField AssertDataField(string name, Type type, string value, int dataFieldCount = 0, IEnumerable<IDataField> dataFields = null)
        {
            var field = dataFields.Get(name);
            field.Namespace.ShouldBeNull();
            field.Type.ShouldEqual(type.ToString());
            field.Value.ShouldEqual(value);
            if (field.DataFields != null)
                field.DataFields.Count().ShouldEqual(dataFieldCount);
            return field;
        }

        public static IDataField AssertDataField(string name, string definition, string label, double costOfSale, bool isSelected, int order, Type type, int industryCount = 0, int dataFieldCount = 0, IEnumerable<IDataField> dataFields = null)
        {
            var field = dataFields.Get(name);
            field.Definition.ShouldEqual(definition);
            field.Label.ShouldEqual(label);
            field.CostOfSale.ShouldEqual(costOfSale);
            field.IsSelected.ShouldEqual(isSelected);
            field.Namespace.ShouldBeNull();
            field.Order.ShouldEqual(order);
            field.Type.ShouldEqual(type.ToString());
            field.Value.ShouldBeNull();
            field.Industries.Count().ShouldEqual(industryCount);
            field.DataFields.Count().ShouldEqual(dataFieldCount);
            return field;
        }
    }
}