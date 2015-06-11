using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Responses
{
    public class LightstoneCompanyResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideDataFromLightstoneBusinessCompany, IEnumerable<DataField>>()
               .ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            Mapper.CreateMap<IEnumerable<IProvideCompany>, DataField>()
              .ForMember(s => s.Name, opt => opt.MapFrom(x => "Companies"))
              .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
              .ForMember(d => d.DataFields, opt => opt.MapFrom(x => x != null ? x.SelectMany(Mapper.Map<object, IEnumerable<DataField>>).ToList() : Enumerable.Empty<IDataField>()));
            Mapper.CreateMap<IProvideCompany, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
        }
    }
}