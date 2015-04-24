using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities.RequestFields;
using Lace.Domain.Core.Entities.Requests;
using Lace.Domain.Core.Requests.Contracts.Requests;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Requests
{
    public class IvidRequestMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IAmDataProviderRequest, IEnumerable<IDataField>>()
                .ConvertUsing<ITypeConverter<IAmDataProviderRequest, IEnumerable<IDataField>>>();

            Mapper.CreateMap<IProvideDataFromAnpr, IEnumerable<IDataField>>()
                .ConvertUsing(s => Enumerable.Empty<IDataField>());
            Mapper.CreateMap<IProvideDataFromAudatex, IEnumerable<IDataField>>()
                .ConvertUsing(s => Enumerable.Empty<IDataField>());
            Mapper.CreateMap<IProvideDataFromJis, IEnumerable<IDataField>>()
                .ConvertUsing(s => Enumerable.Empty<IDataField>());
            Mapper.CreateMap<IProvideDataFromLightstoneAuto, IEnumerable<IDataField>>()
                .ConvertUsing(s =>
                {
                    var request = s.Request ?? new LightstoneAutoRequest(new CarIdRequestField(""), new YearRequestField(""), new MakeRequestField(""), new VinNumberRequestField(""));
                    return Mapper.Map<IAmDataProviderRequest, IEnumerable<IDataField>>(request).ToList();
                });
            Mapper.CreateMap<IProvideDataFromLightstoneBusiness, IEnumerable<IDataField>>()
                .ConvertUsing(s => Enumerable.Empty<IDataField>());
            Mapper.CreateMap<IProvideDataFromLightstoneProperty, IEnumerable<IDataField>>()
               .ConvertUsing(s => Enumerable.Empty<IDataField>());
            Mapper.CreateMap<IProvideDataFromPCubedFicaVerfication, IEnumerable<IDataField>>()
                .ConvertUsing(s => Enumerable.Empty<IDataField>());
            Mapper.CreateMap<IProvideDataFromRgt, IEnumerable<IDataField>>()
               .ConvertUsing(s =>
               {
                   var request = s.Request ?? new RgtRequest(new CarIdRequestField(""));
                   return Mapper.Map<IAmDataProviderRequest, IEnumerable<IDataField>>(request).ToList();
               });
            Mapper.CreateMap<IProvideDataFromRgtVin, IEnumerable<IDataField>>()
               .ConvertUsing(s =>
               {
                   var request = s.Request ?? new RgtVinRequest(new VinNumberRequestField(""));
                   return Mapper.Map<IAmDataProviderRequest, IEnumerable<IDataField>>(request).ToList();
               });
            Mapper.CreateMap<IProvideDataFromSignioDriversLicenseDecryption, IEnumerable<IDataField>>()
               .ConvertUsing(s => Enumerable.Empty<IDataField>());
            Mapper.CreateMap<IProvideDataFromIvid, IEnumerable<IDataField>>()
                .ConvertUsing(s =>
                {
                    var request = s.Request ?? new IvidStandardRequest(
                                                    new RequesterNameRequestField(""),
                                                    new RequesterPhoneRequestField(""),
                                                    new RequesterEmailRequestField(""),
                                                    new RequestReferenceRequestField(""),
                                                    new ApplicantNameRequestField(""),
                                                    new ReasonForApplicationRequestField(""),
                                                    new LabelRequestField(""),
                                                    new VinNumberRequestField(""),
                                                    new ChassisNumberRequestField(""),
                                                    new EngineNumberRequestField(""),
                                                    new RegisterNumberRequestField(""),
                                                    new LicenseNumberRequestField(""),
                                                    new MakeRequestField(""));
                    return Mapper.Map<IAmDataProviderRequest, IEnumerable<IDataField>>(request).ToList();
                });
            Mapper.CreateMap<IProvideDataFromIvidTitleHolder, IEnumerable<IDataField>>()
                .ConvertUsing(s =>
                {
                    var request = s.Request ?? new IvidTitleholderRequest(new RequesterNameRequestField(""), new RequesterPhoneRequestField(""), new RequesterEmailRequestField(""), new VinNumberRequestField(""));
                    return Mapper.Map<IAmDataProviderRequest, IEnumerable<IDataField>>(request).ToList();
                });
        }
    }
}