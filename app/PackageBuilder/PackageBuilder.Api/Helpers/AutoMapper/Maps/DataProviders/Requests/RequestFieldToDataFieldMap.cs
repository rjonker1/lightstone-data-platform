﻿using AutoMapper;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.Enums.Requests;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Requests
{
    public class RequestFieldToDataFieldMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            const string oldValue = "RequestField";
            Mapper.CreateMap<IAmApplicantNameRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "").SplitCamelCase()))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.ApplicantName));
            Mapper.CreateMap<IAmEngineNumberRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "").SplitCamelCase()))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.EngineNumber));
            Mapper.CreateMap<IAmLabelRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "").SplitCamelCase()))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.Label));
            Mapper.CreateMap<IAmVinNumberRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "").SplitCamelCase()))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.VinNumber));
            Mapper.CreateMap<IAmChassisNumberRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "").SplitCamelCase()))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.ChassisNumber));
            Mapper.CreateMap<IAmLicenceNumberRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "").SplitCamelCase()))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.LicenseNumber));
            Mapper.CreateMap<IAmMakeRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "").SplitCamelCase()))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.Make));
            Mapper.CreateMap<IAmReasonForApplicationRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "").SplitCamelCase()))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.ReasonForApplication));
            Mapper.CreateMap<IAmRegisterNumberRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "").SplitCamelCase()))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.RegisterNumber));
            Mapper.CreateMap<IAmRequesterEmailRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "").SplitCamelCase()))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.RequesterEmail));
            Mapper.CreateMap<IAmRequesterNameRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "").SplitCamelCase()))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.RequesterName));
            Mapper.CreateMap<IAmRequesterPhoneRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "").SplitCamelCase()))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.RequesterPhone));
            Mapper.CreateMap<IAmRequestReferenceRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "").SplitCamelCase()))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.RequestReference));
            Mapper.CreateMap<IAmCarIdRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "").SplitCamelCase()))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.CarId));
            Mapper.CreateMap<IAmYearRequestField, DataField>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.GetType().Name.Replace(oldValue, "").SplitCamelCase()))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => (int)RequestFieldType.Year));

            Mapper.CreateMap<IDataField, IAmRequestField>()
                .ConvertUsing<ITypeConverter<IDataField, IAmRequestField>>();
        }
    }
}