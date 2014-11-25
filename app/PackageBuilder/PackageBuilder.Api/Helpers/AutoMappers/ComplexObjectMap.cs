using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Metric;
using PackageBuilder.Core.Helpers.Extensions;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMappers
{
    public class ComplexObjectMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            //Mapper.CreateMap<object, IEnumerable<IDataField>>()
            //    .ConvertUsing(s =>
            //    {
            //        var properties = s.GetType().GetPublicProperties();
            //        var complexProperties = properties
            //            .Where(property => (property.PropertyType.IsClass || property.PropertyType.IsInterface) && !TypeExtensions.IsSimple(property.PropertyType) && property.PropertyType != typeof (IPair<string, double>[])).ToList();
            //        var list = complexProperties.Select(property => Mapper.Map(property.GetValue(s), property.PropertyType, typeof (IDataField)) as IDataField).ToList();
            //        list.AddRange(properties.Except(complexProperties).Select(field => new DataField(field.Name, field.PropertyType, Enumerable.Empty<Industry>())).ToList());
            //        return list;
            //    });

            Mapper.CreateMap<object, IEnumerable<IDataField>>()
                .ConvertUsing<ITypeConverter<object, IEnumerable<IDataField>>>();
        }
    }

    public class ComplexObjectToDataFieldConverter : TypeConverter<object, IEnumerable<IDataField>>
    {
        private readonly IRepository<Industry> _industryRepo;

        public ComplexObjectToDataFieldConverter(IRepository<Industry> industryRepo)
        {
            _industryRepo = industryRepo;
        }

        protected override IEnumerable<IDataField> ConvertCore(object source)
        {
             var properties = source.GetType().GetPublicProperties();
                    var complexProperties = properties
                        .Where(property => (property.PropertyType.IsClass || property.PropertyType.IsInterface) && !TypeExtensions.IsSimple(property.PropertyType) && property.PropertyType != typeof (IPair<string, double>[])).ToList();
                    var list = complexProperties.Select(property => Mapper.Map(property.GetValue(source), property.PropertyType, typeof(IDataField)) as IDataField).ToList();
                    list.AddRange(properties.Except(complexProperties).Select(field => new DataField(field.Name, field.PropertyType, _industryRepo.ToList())).ToList());
                    return list;
        }
    }
}