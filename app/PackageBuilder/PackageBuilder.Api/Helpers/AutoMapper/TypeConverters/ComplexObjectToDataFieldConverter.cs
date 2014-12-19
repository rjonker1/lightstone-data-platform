using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Metric;
using PackageBuilder.Core.Helpers.Extensions;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class ComplexObjectToDataFieldConverter : TypeConverter<object, IEnumerable<IDataField>>
    {
        private readonly IRepository<Industry> _industryRepository;

        public ComplexObjectToDataFieldConverter(IRepository<Industry> industryRepository)
        {
            _industryRepository = industryRepository;
        }

        protected override IEnumerable<IDataField> ConvertCore(object source)
        {
            var properties = source.GetType().GetPublicProperties();
            var complexProperties = properties
                .Where(property => (property.PropertyType.IsClass || property.PropertyType.IsInterface) && !TypeExtensions.IsSimple(property.PropertyType) && property.PropertyType != typeof (IPair<string, double>[])).ToList();
            var list = complexProperties.Select(property => Mapper.Map(property.GetValue(source), property.PropertyType, typeof(IDataField)) as IDataField).ToList();
            list.AddRange(properties.Except(complexProperties).Select(field => new DataField(field.Name, field.PropertyType, _industryRepository.ToList())).ToList());
            return list;
        }
    }
}