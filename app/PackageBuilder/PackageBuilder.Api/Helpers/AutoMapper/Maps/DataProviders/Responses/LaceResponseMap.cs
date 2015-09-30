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
                .Include<IProvideDataFromPCubedFicaVerfication, DataProviderName>()
                .Include<IProvideDataFromPCubedEzScore, DataProviderName>()
                .Include<IProvideDataFromLightstoneBusinessCompany, DataProviderName>()
                .Include<IProvideDataFromLightstoneBusinessDirector, DataProviderName>()
                .Include<IProvideDataFromLightstoneConsumerSpecifications, DataProviderName>()
                .Include<IProvideDataFromBmwFinance, DataProviderName>()
                .Include<IProvideDataFromMmCode, DataProviderName>();

            Mapper.CreateMap<IProvideDataFromIvid, DataProviderName>().ConvertUsing(s => DataProviderName.IVIDVerify_E_WS);
            Mapper.CreateMap<IProvideDataFromIvidTitleHolder, DataProviderName>().ConvertUsing(s => DataProviderName.IVIDTitle_E_WS);
            Mapper.CreateMap<IProvideDataFromLightstoneAuto, DataProviderName>().ConvertUsing(s => DataProviderName.LSAutoCarStats_I_DB);
            Mapper.CreateMap<IProvideDataFromRgt, DataProviderName>().ConvertUsing(s => DataProviderName.LSAutoSpecs_I_DB);
            Mapper.CreateMap<IProvideDataFromRgtVin, DataProviderName>().ConvertUsing(s => DataProviderName.LSAutoVINMaster_I_DB);
            Mapper.CreateMap<IProvideDataFromAudatex, DataProviderName>().ConvertUsing(s => DataProviderName.Audatex);
            Mapper.CreateMap<IProvideDataFromLightstoneProperty, DataProviderName>().ConvertUsing(s => DataProviderName.LSPropertySearch_E_WS);
            Mapper.CreateMap<IProvideDataFromLightstoneBusinessCompany, DataProviderName>().ConvertUsing(s => DataProviderName.LSBusinessCompany_E_WS);
            Mapper.CreateMap<IProvideDataFromSignioDriversLicenseDecryption, DataProviderName>().ConvertUsing(s => DataProviderName.LSAutoDecryptDriverLic_I_WS);
            Mapper.CreateMap<IProvideDataFromPCubedFicaVerfication, DataProviderName>().ConvertUsing(s => DataProviderName.PCubedFica_E_WS);
            Mapper.CreateMap<IProvideDataFromLightstoneBusinessDirector, DataProviderName>().ConvertUsing(s => DataProviderName.LSBusinessDirector_E_WS);
            Mapper.CreateMap<IProvideDataFromLightstoneConsumerSpecifications, DataProviderName>().ConvertUsing(s => DataProviderName.LSConsumerRepair_E_WS);
            Mapper.CreateMap<IProvideDataFromPCubedEzScore, DataProviderName>().ConvertUsing(s => DataProviderName.PCubedEZScore_E_WS);
            Mapper.CreateMap<IProvideDataFromBmwFinance, DataProviderName>().ConvertUsing(s => DataProviderName.BMWFSTitle_E_DB);
            Mapper.CreateMap<IProvideDataFromMmCode, DataProviderName>().ConvertUsing(s => DataProviderName.MMCode_E_DB);

            Mapper.CreateMap<IPointToLaceProvider, DataProvider>()
                .ForMember(d => d.Name, opt => opt.MapFrom(x => Mapper.Map(x, x.GetType(), typeof(DataProviderName))))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map(x, x.GetType(), typeof(IEnumerable<DataField>)) as IEnumerable<DataField>));

            Mapper.CreateMap<IDataProvider, DataProvider>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .BeforeMap((s, d) =>
                {
                    if (s.DataFields != null)
                    {
                        s.DataFields.ToNamespace().ToList()
                               .RecursiveForEach(laceResponseField =>
                               {
                                   var destField = d.DataFields
                                       .ToNamespace()
                                       .ToList()
                                       .Filter(f => f.Namespace == laceResponseField.Namespace)
                                       .FirstOrDefault();
                                   if (destField != null)
                                       Mapper.Map(destField, laceResponseField, typeof (DataField), typeof (DataField), options => options.BeforeMap((src, des) => destField.SetValue(laceResponseField.Value)));
                               });

                        // IEnumerableExtensions - extension method for below 
                        s.DataFields = s.DataFields.GetSelected();
                    }
                })
            .ForMember(d => d.DataFields, opt => opt.Ignore());

            Mapper.CreateMap<IDataField, DataField>()
                .ForMember(d => d.IsSelected, opt => opt.Ignore());
        }
    }
}