using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Entities;
using Lace.Domain.Core.Contracts.DataProviders.Metric;
using PackageBuilder.Core.Helpers.Extensions;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMappers
{
    public class ComplexObjectMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<object, IEnumerable<IDataField>>()
                .ConvertUsing(s =>
                {
                    var properties = s.GetType().GetPublicProperties();
                    var complexProperties = properties
                        .Where(property => (property.PropertyType.IsClass || property.PropertyType.IsInterface) && !TypeExtensions.IsSimple(property.PropertyType) && property.PropertyType != typeof (IPair<string, double>[])).ToList();
                    var list = complexProperties.Select(property => Mapper.Map(property.GetValue(s), property.PropertyType, typeof (IDataField)) as IDataField).ToList();
                    list.AddRange(properties.Except(complexProperties).Select(field => new DataField(field.Name, field.PropertyType)));
                    return list;
                });
        }
    }
}