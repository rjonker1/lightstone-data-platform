using System.Collections.Generic;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.DriversLicense;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Write.Responses
{
    public class SignioDriversLicenseResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideDataFromSignioDriversLicenseDecryption, IEnumerable<DataField>>()
              .ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);

            Mapper.CreateMap<IRespondWithDriversLicenseCard, DataField>()
                .ForMember(d => d.Name, opt => opt.MapFrom(x => "DrivingLicenseCard"))
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map<object, IEnumerable<DataField>>(x)));

            Mapper.CreateMap<IRespondWithIdentityDocument, DataField>()
                .ForMember(d => d.Name, opt => opt.MapFrom(x => "IdentityDocument"))
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map<object, IEnumerable<DataField>>(x)));

            Mapper.CreateMap<IRespondWithCard, DataField>()
                .ForMember(d => d.Name, opt => opt.MapFrom(x => "Card"))
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map<object, IEnumerable<DataField>>(x)));

            Mapper.CreateMap<IRespondWithDrivingLicense, DataField>()
                .ForMember(d => d.Name, opt => opt.MapFrom(x => "DrivingLicense"))
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map<object, IEnumerable<DataField>>(x)));

            Mapper.CreateMap<IRespondWithPerson, DataField>()
                .ForMember(d => d.Name, opt => opt.MapFrom(x => "Person"))
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map<object, IEnumerable<DataField>>(x)));

            Mapper.CreateMap<IRespondWithProfessionalDrivingPermit, DataField>()
                .ForMember(d => d.Name, opt => opt.MapFrom(x => "ProfessionalDrivingPermit"))
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map<object, IEnumerable<DataField>>(x)));

            Mapper.CreateMap<IRespondWithVehicleClass, DataField>()
                .ForMember(d => d.Name, opt => opt.MapFrom(x => "VehicleClass1"))
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map<object, IEnumerable<DataField>>(x)));

            Mapper.CreateMap<IRespondWithVehicleClass, DataField>()
                .ForMember(d => d.Name, opt => opt.MapFrom(x => "VehicleClass2"))
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map<object, IEnumerable<DataField>>(x)));

            Mapper.CreateMap<IRespondWithVehicleClass, DataField>()
                .ForMember(d => d.Name, opt => opt.MapFrom(x => "VehicleClass3"))
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map<object, IEnumerable<DataField>>(x)));

            Mapper.CreateMap<IRespondWithVehicleClass, DataField>()
                .ForMember(d => d.Name, opt => opt.MapFrom(x => "VehicleClass4"))
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map<object, IEnumerable<DataField>>(x)));
        }
    }
}