﻿using System.Collections.Generic;
using AutoMapper;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class DataFieldDtoToDataFieldConverter : TypeConverter<DataProviderFieldItemDto, IDataField>
    {
        private readonly IRepository<Industry> _industryRepo;

        public DataFieldDtoToDataFieldConverter(IRepository<Industry> industryRepo)
        {
            _industryRepo = industryRepo;
        }

        protected override IDataField ConvertCore(DataProviderFieldItemDto source)
        {
            //return new DataField(source.Name, source.Label, source.Definition, _industryRepo.ToList(),
            //    System.Convert.ToDouble(source.Price), System.Convert.ToBoolean(source.IsSelected),
            //    Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>(source.DataFields));
            
            return new DataField(source.Name, source.Label, source.Definition, source.Industries,
                System.Convert.ToDouble(source.Price), System.Convert.ToBoolean(source.IsSelected),
                Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>(source.DataFields));
        }
    }
}