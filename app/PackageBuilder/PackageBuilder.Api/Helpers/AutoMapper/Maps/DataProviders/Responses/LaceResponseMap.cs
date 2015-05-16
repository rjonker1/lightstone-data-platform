using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Responses
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
                .ForMember(d => d.Name, opt => opt.MapFrom(x => Mapper.Map(x, x.GetType(), typeof(DataProviderName))))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map(x, x.GetType(), typeof(IEnumerable<DataField>)) as IEnumerable<DataField>));

            Mapper.CreateMap<IDataProvider, DataProvider>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .BeforeMap((s, d) =>
                {
                    if (s.DataFields != null)
                    {
                        var objects = s.DataFields.ToNamespace().Select(x => (IDataField)Mapper.Map(x, d.DataFields.ToNamespace().Filter(f => x != null && f.Namespace == x.Namespace)
                            .FirstOrDefault(), typeof(IDataField), typeof(DataField))).ToList();
                        d.DataFields = objects.Filter(x => x.IsSelected == true);
                    }
                })
            .ForMember(d => d.DataFields, opt => opt.Ignore());

            Mapper.CreateMap<IDataField, DataField>()
                .ForMember(d => d.IsSelected, opt => opt.Ignore());
        }
    }
}