using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using Nancy.Extensions;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMappers
{
    public class DataFieldMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IDataField, DataProviderFieldItemDto>()
                .ForMember(dest => dest.Industries, opt => opt.MapFrom(x => x.Industries != null ?

                    x.Industries.ToList().Concat(ServiceLocator.Current.GetInstance<IRepository<Industry>>().ToList()).DistinctBy(c => c.Id) :
                    ServiceLocator.Current.GetInstance<IRepository<Industry>>().ToList()));

            Mapper.CreateMap<IEnumerable<IDataField>, IEnumerable<DataProviderFieldItemDto>>()
                .ConvertUsing(s =>
                {
                    if (s == null) return Enumerable.Empty<DataProviderFieldItemDto>();
                    var dataProviderFieldItemDtos = s.Select(Mapper.Map<IDataField, DataProviderFieldItemDto>).ToList();
                    return dataProviderFieldItemDtos;
                });

            Mapper.CreateMap<DataProviderFieldItemDto, IDataField>()
                .ConvertUsing<ITypeConverter<DataProviderFieldItemDto, IDataField>>();
            Mapper.CreateMap<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>()
                .ConvertUsing(s =>
                {
                    if (s == null) return Enumerable.Empty<IDataField>();
                    var dataProviderFieldItemDtos = s.Select(Mapper.Map<DataProviderFieldItemDto, IDataField>).ToList();
                    return dataProviderFieldItemDtos;
                });

        }
    }

    public class IndustryResolver : ValueResolver<IEnumerable<Industry>, IEnumerable<Industry>>
    {
        private readonly IRepository<Industry> _industryRepo;

        public IndustryResolver(IRepository<Industry> industryRepo)
        {
            _industryRepo = industryRepo;
        }

        protected override IEnumerable<Industry> ResolveCore(IEnumerable<Industry> source)
        {
            return _industryRepo.Union(source);
        }
    }

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