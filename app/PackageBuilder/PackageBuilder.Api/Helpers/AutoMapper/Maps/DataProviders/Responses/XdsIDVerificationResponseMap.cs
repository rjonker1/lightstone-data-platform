using System.Collections.Generic;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Xds;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Responses
{
    public class XdsIdentityVerificationResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideDataFromXdsIdentityVerification, IEnumerable<DataField>>()
                .ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            Mapper.CreateMap<IEnumerable<IRespondWithIdentityVerification>, DataField>()
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(NestedDataFieldBuilder.Build<IRespondWithIdentityVerification>()));
            Mapper.CreateMap<IRespondWithIdentityVerification, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
        }
    }
}