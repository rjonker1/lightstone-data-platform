using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities.Requests;
using Lace.Domain.Core.Entities.Requests.Fields;
using Lace.Domain.Core.Requests.Contracts;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Requests
{
    public class IvidRequestMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IAmDataProviderRequest, IEnumerable<IAmRequestField>>()
                .ConvertUsing<ITypeConverter<IAmDataProviderRequest, IEnumerable<IAmRequestField>>>();

            Mapper.CreateMap<IProvideDataFromAnpr, IEnumerable<IAmRequestField>>()
                .ConvertUsing(s => Enumerable.Empty<IAmRequestField>());
            Mapper.CreateMap<IProvideDataFromAudatex, IEnumerable<IAmRequestField>>()
                .ConvertUsing(s => Enumerable.Empty<IAmRequestField>());
            Mapper.CreateMap<IProvideDataFromJis, IEnumerable<IAmRequestField>>()
                .ConvertUsing(s => Enumerable.Empty<IAmRequestField>());
            Mapper.CreateMap<IProvideDataFromLightstoneAuto, IEnumerable<IAmRequestField>>()
                .ConvertUsing(s => Enumerable.Empty<IAmRequestField>());
            Mapper.CreateMap<IProvideDataFromLightstoneBusiness, IEnumerable<IAmRequestField>>()
                .ConvertUsing(s => Enumerable.Empty<IAmRequestField>());
            Mapper.CreateMap<IProvideDataFromLightstoneProperty, IEnumerable<IAmRequestField>>()
                .ConvertUsing(s => Enumerable.Empty<IAmRequestField>());
            Mapper.CreateMap<IProvideDataFromPCubedFicaVerfication, IEnumerable<IAmRequestField>>()
                .ConvertUsing(s => Enumerable.Empty<IAmRequestField>());
            Mapper.CreateMap<IProvideDataFromRgt, IEnumerable<IAmRequestField>>()
               .ConvertUsing(s => Enumerable.Empty<IAmRequestField>());
            Mapper.CreateMap<IProvideDataFromRgtVin, IEnumerable<IAmRequestField>>()
               .ConvertUsing(s => Enumerable.Empty<IAmRequestField>());
            Mapper.CreateMap<IProvideDataFromSignioDriversLicenseDecryption, IEnumerable<IAmRequestField>>()
               .ConvertUsing(s => Enumerable.Empty<IAmRequestField>());
            Mapper.CreateMap<IProvideDataFromIvid, IEnumerable<IAmRequestField>>()
                .ConvertUsing(s =>
                {
                    var request = s.Request ?? new IvidStandardRequest(
                                                    new RequesterNameRequestField(),
                                                    new RequesterPhoneRequestField(),
                                                    new RequesterEmailRequestField(),
                                                    new RequestReferenceRequestField(),
                                                    new ApplicantNameRequestField(),
                                                    new ReasonForApplicationRequestField(), 
                                                    new LabelRequestField(),
                                                    new EngineNumberRequestField(),
                                                    new RegisterNumberRequestField(),
                                                    new LicenseNumberRequestField(),
                                                    new MakeRequestField());
                    return Mapper.Map<IAmDataProviderRequest, IEnumerable<IAmRequestField>>(request).ToList();
                });
            Mapper.CreateMap<IProvideDataFromIvidTitleHolder, IEnumerable<IAmRequestField>>()
                .ConvertUsing(s => Enumerable.Empty<IAmRequestField>());
        }
    }
}