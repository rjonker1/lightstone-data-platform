﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Core.Helpers.Extensions;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class RequestToDataFieldConverter : TypeConverter<IAmDataProviderRequest, IEnumerable<IAmRequestField>>
    {
        protected override IEnumerable<IAmRequestField> ConvertCore(IAmDataProviderRequest source)
        {
            var properties = source.GetType().GetPublicProperties();

            return properties.Select(property => AmRequestField(source, property));
        }

        private static IAmRequestField AmRequestField(IAmDataProviderRequest source, PropertyInfo property)
        {
            return Mapper.Map(property.GetValue(source), property.PropertyType, typeof(IAmRequestField)) as IAmRequestField;
        }
    }
}