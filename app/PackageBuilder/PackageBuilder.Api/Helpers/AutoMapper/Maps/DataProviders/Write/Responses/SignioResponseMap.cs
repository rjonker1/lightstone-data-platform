using System.Collections.Generic;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.DriversLicense;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Write.Responses
{
    public class SignioDriversLicenseResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideDataFromSignioDriversLicenseDecryption, IEnumerable<IDataField>>()
              .ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);

            Mapper.CreateMap<IRespondWithDriversLicenseCard, IDataField>()
                .ConvertUsing(s => new DataField("DrivingLicense", s.GetType(), Mapper.Map<object, IEnumerable<IDataField>>(s)));

            Mapper.CreateMap<IRespondWithIdentityDocument, IDataField>()
                .ConvertUsing(s => new DataField("IdentityDocument", s.GetType(), Mapper.Map<object, IEnumerable<IDataField>>(s)));

            Mapper.CreateMap<IRespondWithCard, IDataField>()
                .ConvertUsing(s => new DataField("Card", s.GetType(), Mapper.Map<object, IEnumerable<IDataField>>(s)));

            Mapper.CreateMap<IRespondWithDrivingLicense, IDataField>()
                .ConvertUsing(s => new DataField("DrivingLicense", s.GetType(), Mapper.Map<object, IEnumerable<IDataField>>(s)));

            Mapper.CreateMap<IRespondWithPerson, IDataField>()
                .ConvertUsing(s => new DataField("Person", s.GetType(), Mapper.Map<object, IEnumerable<IDataField>>(s)));

            Mapper.CreateMap<IRespondWithProfessionalDrivingPermit, IDataField>()
                .ConvertUsing(s => new DataField("ProfessionalDrivingPermit", s.GetType(), Mapper.Map<object, IEnumerable<IDataField>>(s)));

            Mapper.CreateMap<IRespondWithVehicleClass, IDataField>()
                .ConvertUsing(s => new DataField("VehicleClass1", s.GetType(), Mapper.Map<object, IEnumerable<IDataField>>(s)));

            Mapper.CreateMap<IRespondWithVehicleClass, IDataField>()
               .ConvertUsing(s => new DataField("VehicleClass2", s.GetType(), Mapper.Map<object, IEnumerable<IDataField>>(s)));

            Mapper.CreateMap<IRespondWithVehicleClass, IDataField>()
               .ConvertUsing(s => new DataField("VehicleClass3", s.GetType(), Mapper.Map<object, IEnumerable<IDataField>>(s)));

            Mapper.CreateMap<IRespondWithVehicleClass, IDataField>()
               .ConvertUsing(s => new DataField("VehicleClass4", s.GetType(), Mapper.Map<object, IEnumerable<IDataField>>(s)));


            Mapper.CreateMap<IRespondWithDrivingLicense, IDataField>()
                .ConvertUsing(s => new DataField("DrivingLicense", s.GetType(), Mapper.Map<object, IEnumerable<IDataField>>(s)));
        }
    }
}