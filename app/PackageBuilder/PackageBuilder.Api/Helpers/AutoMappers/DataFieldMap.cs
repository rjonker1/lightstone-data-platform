using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMappers
{
    public class DataFieldMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IDataField, DataProviderFieldItemDto>();
            Mapper.CreateMap<IEnumerable<IDataField>, IEnumerable<DataProviderFieldItemDto>>()
                .ConvertUsing(s => s.Select(Mapper.Map<IDataField, DataProviderFieldItemDto>));

            Mapper.CreateMap<DataProviderFieldItemDto, IDataField>()
                .ConvertUsing(s => new DataField(s.Name, s.Label, s.Definition, s.Industries, Convert.ToDouble(s.Price), Convert.ToBoolean(s.IsSelected)));//, Type.GetType(s.Type)));
            Mapper.CreateMap<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>()
                .ConvertUsing(x => x.Select(Mapper.Map<DataProviderFieldItemDto, IDataField>).ToList());
                //.ConvertUsing(x => x.Where(y => y.IsSelected != null && y.IsSelected.Value).Select(Mapper.Map<DataProviderFieldItemDto, IDataField>));
        }
    }
}