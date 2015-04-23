using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities.Requests;
using Lace.Domain.Core.Entities.Requests.Fields;
using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.Enums.Requests;

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
                .ConvertUsing(s => Enumerable.Empty<IDataField>());
            Mapper.CreateMap<IProvideDataFromLightstoneBusiness, IEnumerable<IDataField>>()
                .ConvertUsing(s => Enumerable.Empty<IDataField>());
            Mapper.CreateMap<IProvideDataFromLightstoneProperty, IEnumerable<IDataField>>()
                .ConvertUsing(s => Enumerable.Empty<IDataField>());
            Mapper.CreateMap<IProvideDataFromPCubedFicaVerfication, IEnumerable<IDataField>>()
                .ConvertUsing(s => Enumerable.Empty<IDataField>());
            Mapper.CreateMap<IProvideDataFromRgt, IEnumerable<IDataField>>()
               .ConvertUsing(s => Enumerable.Empty<IDataField>());
            Mapper.CreateMap<IProvideDataFromRgtVin, IEnumerable<IDataField>>()
               .ConvertUsing(s => Enumerable.Empty<IDataField>());
            Mapper.CreateMap<IProvideDataFromSignioDriversLicenseDecryption, IEnumerable<IDataField>>()
               .ConvertUsing(s => Enumerable.Empty<IDataField>());
            Mapper.CreateMap<IProvideDataFromIvid, IEnumerable<IDataField>>()
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
                    return Mapper.Map<IAmDataProviderRequest, IEnumerable<IDataField>>(request).ToList();
                });
            Mapper.CreateMap<IProvideDataFromIvidTitleHolder, IEnumerable<IDataField>>()
                .ConvertUsing(s => Enumerable.Empty<IDataField>());

            

        }
    }

    public class RequestFieldMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            const string oldValue = "RequestField";
            Mapper.CreateMap<IAmApplicantNameRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "")))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.ApplicantName));
            Mapper.CreateMap<IAmEngineNumberRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "")))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.EngineNumber));
            Mapper.CreateMap<IAmLabelRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "")))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.Label));
            Mapper.CreateMap<IAmLicenseNumberRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "")))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.LicenseNumber));
            Mapper.CreateMap<IAmMakeRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "")))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.Make));
            Mapper.CreateMap<IAmReasonForApplicationRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "")))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.ReasonForApplication));
            Mapper.CreateMap<IAmRegisterNumberRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "")))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.RegisterNumber));
            Mapper.CreateMap<IAmRequesterEmailRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "")))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.RequesterEmail));
            Mapper.CreateMap<IAmRequesterNameRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "")))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.RequesterName));
            Mapper.CreateMap<IAmRequesterPhoneRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "")))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.RequesterPhone));
            Mapper.CreateMap<IAmRequestReferenceRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "")))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.RequestReference));



            Mapper.CreateMap<IDataField, IAmRequestField>()
               .ConvertUsing<ITypeConverter<IDataField, IAmRequestField>>();

        }
    }

    public class DataToRequestFieldConverter : TypeConverter<IDataField, IAmRequestField>
    {
        protected override IAmRequestField ConvertCore(IDataField source)
        {
            var requestType = (RequestFieldType)Enum.Parse(typeof(RequestFieldType), source.Type);

            //if (requestType == RequestFieldType.ApplicantName)
            //{
            //    return new ApplicantNameRequestField()
            //}

            return null;
        }
    }
}