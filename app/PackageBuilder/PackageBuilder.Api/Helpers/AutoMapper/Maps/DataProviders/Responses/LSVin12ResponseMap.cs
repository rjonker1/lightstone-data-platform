using System.Collections.Generic;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Vin12;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Responses
{
    public class Vin12ResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideDataFromVin12, IEnumerable<DataField>>()
                .ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            Mapper.CreateMap<IEnumerable<IRespondWithVin12>, DataField>()
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(NestedDataFieldBuilder.Build<IRespondWithVin12>()));
            Mapper.CreateMap<IProvideDataFromVin12, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
        }
    }
}