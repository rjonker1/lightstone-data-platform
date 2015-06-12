using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Requests;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using PackageBuilder.Domain.Requests.Fields;

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
                    var request = s.Request ??
                                  new LightstoneAutoRequest(new CarIdRequestField(""), new YearRequestField(""), new MakeRequestField(""),
                                      new VinNumberRequestField(""));
                    return Mapper.Map<IAmDataProviderRequest, IEnumerable<IDataField>>(request).ToList();
                });


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
                        //new RequesterNameRequestField(""),
                        //new RequesterPhoneRequestField(""),
                        //new RequesterEmailRequestField(""),
                        //new RequestReferenceRequestField(""),
                        //new ApplicantNameRequestField(""),
                        //new ReasonForApplicationRequestField(""),
                        //new LabelRequestField(""),
                        new EngineNumberRequestField(""),
                        new ChassisNumberRequestField(""),
                        new VinNumberRequestField(""),
                        new LicenceNumberRequestField(""),
                        new RegisterNumberRequestField(""),
                        new MakeRequestField(""));
                    return Mapper.Map<IAmDataProviderRequest, IEnumerable<IDataField>>(request).ToList();
                });
            Mapper.CreateMap<IProvideDataFromIvidTitleHolder, IEnumerable<IDataField>>()
                .ConvertUsing(s =>
                {
                    var request = s.Request ?? new IvidTitleholderRequest(new VinNumberRequestField(""));
                    return Mapper.Map<IAmDataProviderRequest, IEnumerable<IDataField>>(request).ToList();
                });

            Mapper.CreateMap<IProvideDataFromLightstoneProperty, IEnumerable<IDataField>>().ConvertUsing(s =>
            {
                var request = s.Request ?? new LighstonePropertyRequest(new IdentityNumberRequestField(""));
                return Mapper.Map<IAmDataProviderRequest, IEnumerable<IDataField>>(request).ToList();
            });

            Mapper.CreateMap<IProvideDataFromLightstoneBusinessCompany, IEnumerable<IDataField>>().ConvertUsing(s =>
            {
                var request = s.Request ??
                              new LightstoneCompanyRequest(new CompanyNameRequestField(""), new CompanyRegistrationNumberRequestField(""),
                                  new CompanyVatNumberRequestField(""));
                return Mapper.Map<IAmDataProviderRequest, IEnumerable<IDataField>>(request).ToList();
            });

            Mapper.CreateMap<IProvideDataFromLightstoneBusinessDirector, IEnumerable<IDataField>>().ConvertUsing(s =>
            {
                var request = s.Request ??
                              new LightstoneDirectorRequest(new IdentityNumberRequestField(""), new FirstNameRequestField(""),
                                  new SurnameRequestField(""));
                return Mapper.Map<IAmDataProviderRequest, IEnumerable<IDataField>>(request).ToList();
            });
        }
    }
}