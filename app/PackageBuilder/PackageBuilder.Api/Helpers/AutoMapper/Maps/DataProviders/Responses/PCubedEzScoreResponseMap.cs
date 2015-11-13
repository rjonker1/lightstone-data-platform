using System.Collections.Generic;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Responses
{
    public class PCubedEzScoreResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideDataFromPCubedEzScore, IEnumerable<DataField>>()
              .ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);

            Mapper.CreateMap<IEnumerable<IRespondWithEzScore>, DataField>()
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(NestedDataFieldBuilder.Build<IRespondWithEzScore>()));
            Mapper.CreateMap<IRespondWithEzScore, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
        }
    }
}