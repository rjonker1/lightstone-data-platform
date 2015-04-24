using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Lace.Domain.Core.Requests.Contracts.Requests;
using PackageBuilder.Core.Helpers.Extensions;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class RequestToDataFieldConverter : TypeConverter<IAmDataProviderRequest, IEnumerable<IDataField>>
    {
        protected override IEnumerable<IDataField> ConvertCore(IAmDataProviderRequest source)
        {
            var properties = source.GetType().GetPublicProperties();

            return properties.Select(property => AmRequestField(source, property)).ToList();
        }

        private static IDataField AmRequestField(IAmDataProviderRequest source, PropertyInfo property)
        {
            return Mapper.Map(property.GetValue(source), property.PropertyType, typeof(DataField)) as IDataField;
        }
    }
}