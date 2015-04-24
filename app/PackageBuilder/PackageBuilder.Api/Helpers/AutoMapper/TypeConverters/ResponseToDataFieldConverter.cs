using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Helpers.Extensions;
using Lace.Domain.Core.Contracts.DataProviders.Metric;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Core.Requests.Contracts.Requests;
using PackageBuilder.Core.Helpers.Extensions;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.Industries.Read;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class ResponseToDataFieldConverter : TypeConverter<object, IEnumerable<DataField>>
    {
        private readonly IRepository<Industry> _industryRepository;

        public ResponseToDataFieldConverter(IRepository<Industry> industryRepository)
        {
            _industryRepository = industryRepository;
        }

        protected override IEnumerable<DataField> ConvertCore(object source)
        {
            try
            {
                return DataFields(source);
            }
            catch (InvalidOperationException exception)
            {
                this.Error(() => "Failed to map {0} to IEnumerable<IDataField>".FormatWith(source), exception);    
                throw;
            }
        }

        private IEnumerable<DataField> DataFields(object source)
        {
            this.Info(() => "Attempting to map {0} to IEnumerable<IDataField>".FormatWith(source));

            var properties = source.GetType().GetPublicProperties().Where(x => x.Name != "Type" && x.Name != "TypeName"); //Type & TypeName are used for deserialization via DataPlatform.Shared.Helpers.Json.JsonTypeResolverConverter
            var complexProperties = properties.Where(property =>
                        (property.PropertyType.IsClass || property.PropertyType.IsInterface) &&
                        !TypeExtensions.IsSimple(property.PropertyType) && 
                        !property.PropertyType.IsInstanceOfType(Type.GetType("System.Type")) &&
                        property.PropertyType.GetInterface(typeof(IAmDataProviderRequest).FullName) == null &&
                        property.PropertyType != typeof (IPair<string, double>[])).ToList();
            var list = complexProperties.Select(property => Mapper.Map(property.GetValue(source), property.PropertyType, typeof (DataField)) as DataField).ToList();
            list.AddRange(properties.Except(complexProperties).Select(field => new DataField(field.Name, field.PropertyType.ToString(), _industryRepository.ToList(), field.GetValue(source) + "")).ToList());

            this.Info(() => "Successfully mapped {0} to IEnumerable<IDataField>".FormatWith(source));

            return list;
        }
    }
}