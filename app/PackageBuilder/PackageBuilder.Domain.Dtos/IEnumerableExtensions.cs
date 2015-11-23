using System;
using System.Collections.Generic;
using System.Linq;
using PackageBuilder.Domain.Dtos.Write;

namespace PackageBuilder.Domain.Dtos
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<DataProviderFieldItemDto> ToNamespace(this IEnumerable<DataProviderFieldItemDto> dataFields, string namespaceRoot = "")
        {
            if (dataFields == null)
                return Enumerable.Empty<DataProviderFieldItemDto>();

            var fields = dataFields as IList<DataProviderFieldItemDto> ?? dataFields.ToList();
            foreach (var dataField in fields.Where(x => x != null))
            {
                dataField.Namespace = string.IsNullOrEmpty(namespaceRoot) ? dataField.Name : namespaceRoot + "." + dataField.Name;
                dataField.DataFields.ToNamespace(dataField.Namespace);
            }

            return fields;
        }

        public static void RecursiveForEach(this IEnumerable<DataProviderFieldItemDto> dataFields, Action<DataProviderFieldItemDto> action)
        {
            if (dataFields == null) return;
            foreach (var dataField in dataFields.Where(dataField => dataField != null))
            {
                action(dataField);
                dataField.DataFields.RecursiveForEach(action);
            }
        }
    }
}