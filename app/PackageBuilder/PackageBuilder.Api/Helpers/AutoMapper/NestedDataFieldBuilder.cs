using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper
{
    public class NestedDataFieldBuilder
    {
        public static IEnumerable<DataField> Build<T>(IEnumerable<T> objects)
        {
            return objects != null
                ? objects.Select(dataField => new DataField(dataField.GetType().Name, dataField.GetType().ToString(), Mapper.Map<object, IEnumerable<DataField>>(dataField)))
                : Enumerable.Empty<DataField>();
        }
        public static Expression<Func<IEnumerable<T>, IEnumerable<DataField>>> Build<T>()
        {
            return x => x != null
                ? x.Select(dataField => new DataField(dataField.GetType().Name, dataField.GetType().ToString(), Mapper.Map<object, IEnumerable<DataField>>(dataField)))
                : Enumerable.Empty<DataField>();
        }
    }
}