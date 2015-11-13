using System.Collections.Generic;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Responses
{
    public class AudatexResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideDataFromAudatex, IEnumerable<DataField>>()
                .ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);

            Mapper.CreateMap<IEnumerable<IProvideAccidentClaim>, DataField>()
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(NestedDataFieldBuilder.Build<IProvideAccidentClaim>()));
            Mapper.CreateMap<IProvideAccidentClaim, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
        }
    }
}