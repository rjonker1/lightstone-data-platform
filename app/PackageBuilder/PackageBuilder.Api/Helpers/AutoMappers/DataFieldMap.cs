using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
                .ConvertUsing(s =>
                {
                    if (s == null) return Enumerable.Empty<DataProviderFieldItemDto>();
                    var dataProviderFieldItemDtos = s.Select(Mapper.Map<IDataField, DataProviderFieldItemDto>);
                    return dataProviderFieldItemDtos;
                });

            Mapper.CreateMap<DataProviderFieldItemDto, IDataField>()
                .ConvertUsing(s => new DataField(s.Name, s.Label, s.Definition, s.Industry, Convert.ToDouble(s.Price), 
                    Convert.ToBoolean(s.IsSelected), Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>(s.DataFields)));//, Type.GetType(s.Type)));
            Mapper.CreateMap<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>()
                .ConvertUsing(s =>
                {
                    if (s == null) return Enumerable.Empty<IDataField>();
                    var dataProviderFieldItemDtos = s.Select(Mapper.Map<DataProviderFieldItemDto, IDataField>).ToList();
                    return dataProviderFieldItemDtos;
                });

             //.ConvertUsing(x => x.Select(Mapper.Map<DataProviderFieldItemDto, IDataField>).ToList());
                //.ConvertUsing(x => x.Where(y => y.IsSelected != null && y.IsSelected.Value).Select(Mapper.Map<DataProviderFieldItemDto, IDataField>));
            //.ConvertUsing(x => x.Where(y => y.IsSelected != null && y.IsSelected.Value).Select(Mapper.Map<DataProviderFieldItemDto, IDataField>));
        }
    }
}