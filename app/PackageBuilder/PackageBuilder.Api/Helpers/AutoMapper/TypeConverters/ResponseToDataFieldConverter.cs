using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Helpers.Extensions;
using Lace.Domain.Core.Contracts.DataProviders.Metric;
using PackageBuilder.Core.Helpers.Extensions;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.Industries.Read;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Shared.Logging;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class ResponseToDataFieldConverter : TypeConverter<object, IEnumerable<DataField>>
    {
        private readonly IRepository<Industry> _industryRepository;
        private readonly string[] _blackListedProperties = { "Type", "TypeName", "Handled", "Request" };

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

            var properties = source.GetType().GetPublicProperties().AsQueryable().Where(x => !_blackListedProperties.Contains(x.Name)).ToList(); 
            var complexProperties = properties.Where(property =>
                        (property.PropertyType.IsClass || property.PropertyType.IsInterface) &&
                        !TypeExtensions.IsSimple(property.PropertyType) && 
                        !property.PropertyType.IsInstanceOfType(Type.GetType("System.Type")) &&
                        property.PropertyType.GetInterface(typeof(IAmDataProviderRequest).FullName) == null &&
                        property.PropertyType != typeof (IPair<string, double>[])).ToList();
            var list = complexProperties.Select(property => Mapper.Map(property.GetValue(source), property.PropertyType, typeof(DataField), options => options.AfterMap(
                (s, d) =>
                {
                    var dataField = d as DataField;
                    if (dataField != null) dataField.SetName(property.Name);
                }
                )) as DataField).ToList();

            foreach (var field in properties.Except(complexProperties))
            {
                if (field == null) continue;
                var value = "";
                try
                {
                    value = field.GetValue(source) + "";
                }
                catch (Exception)
                {
                    var field1 = field;
                    this.Error(() => "Error getting property value to populate data field value {0}".FormatWith(field1.Name));
                }
                 
                list.Add(new DataField(field.Name, field.PropertyType.ToString(), _industryRepository.ToList(), value));
            }

            this.Info(() => "Successfully mapped {0} to IEnumerable<IDataField>".FormatWith(source));

            return list.Where(x => x != null).ToList();
        }
    }
}