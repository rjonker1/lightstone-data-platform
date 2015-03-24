using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Write
{
    public class LaceResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IPointToLaceProvider, DataProviderName>()
                .Include<IProvideDataFromIvid, DataProviderName>()
                .Include<IProvideDataFromIvidTitleHolder, DataProviderName>()
                .Include<IProvideDataFromLightstoneAuto, DataProviderName>()
                .Include<IProvideDataFromRgt, DataProviderName>()
                .Include<IProvideDataFromRgtVin, DataProviderName>()
                .Include<IProvideDataFromAudatex, DataProviderName>()
                .Include<IProvideDataFromLightstoneProperty, DataProviderName>()
                .Include<IProvideDataFromSignioDriversLicenseDecryption, DataProviderName>()
                .Include<IProvideDataFromPCubedFicaVerfication, DataProviderName>();
            Mapper.CreateMap<IProvideDataFromIvid, DataProviderName>().ConvertUsing(s => DataProviderName.Ivid);
            Mapper.CreateMap<IProvideDataFromIvidTitleHolder, DataProviderName>().ConvertUsing(s => DataProviderName.IvidTitleHolder);
            Mapper.CreateMap<IProvideDataFromLightstoneAuto, DataProviderName>().ConvertUsing(s => DataProviderName.LightstoneAuto);
            Mapper.CreateMap<IProvideDataFromRgt, DataProviderName>().ConvertUsing(s => DataProviderName.Rgt);
            Mapper.CreateMap<IProvideDataFromRgtVin, DataProviderName>().ConvertUsing(s => DataProviderName.RgtVin);
            Mapper.CreateMap<IProvideDataFromAudatex, DataProviderName>().ConvertUsing(s => DataProviderName.Audatex);
            Mapper.CreateMap<IProvideDataFromLightstoneProperty, DataProviderName>().ConvertUsing(s => DataProviderName.LightstoneProperty);
            Mapper.CreateMap<IProvideDataFromSignioDriversLicenseDecryption, DataProviderName>().ConvertUsing(s => DataProviderName.SignioDecryptDriversLicense);
            Mapper.CreateMap<IProvideDataFromPCubedFicaVerfication, DataProviderName>().ConvertUsing(s => DataProviderName.PCubedFica);

            Mapper.CreateMap<IPointToLaceProvider, DataProvider>()
                .ForMember(d => d.Name, opt => opt.MapFrom(x => Mapper.Map(x, x.GetType(), typeof(DataProviderName)))) //Mapper.Map<IPointToLaceProvider, DataProviderName>(x)))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map(x, x.GetType(), typeof(IEnumerable<DataField>)) as IEnumerable<DataField>));

            Mapper.CreateMap<IDataProvider, DataProvider>()
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => x.DataFields.Where(fld => fld.IsSelected == true)));

            Mapper.CreateMap<IEnumerable<IDataField>, IEnumerable<DataField>>()
                .ConvertUsing(s => s != null ? s.Select(Mapper.Map<IDataField, DataField>).ToList() : Enumerable.Empty<DataField>());
            Mapper.CreateMap<IDataField, DataField>()
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => x.DataFields.Where(fld => fld.IsSelected == true)))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<IDataField>, IEnumerable<DataField>>(x.DataFields)));
        }
    }
}