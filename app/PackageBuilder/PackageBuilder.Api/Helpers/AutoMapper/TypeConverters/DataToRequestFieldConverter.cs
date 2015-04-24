using System;
using AutoMapper;
using Lace.Domain.Core.Entities.RequestFields;
using Lace.Domain.Core.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Enums.Requests;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class DataToRequestFieldConverter : TypeConverter<IDataField, IAmRequestField>
    {
        protected override IAmRequestField ConvertCore(IDataField source)
        {
            var requestType = (RequestFieldType)Enum.Parse(typeof(RequestFieldType), source.Type);
            switch (requestType)
            {
                case RequestFieldType.ApplicantName:
                    return new ApplicantNameRequestField(source.Value);
                case RequestFieldType.EngineNumber:
                    return new EngineNumberRequestField(source.Value);
                case RequestFieldType.ChassisNumber:
                    return new ChassisNumberRequestField(source.Value);
                case RequestFieldType.Label:
                    return new LabelRequestField(source.Value);
                case RequestFieldType.LicenseNumber:
                    return new LicenseNumberRequestField(source.Value);
                case RequestFieldType.Make:
                    return new MakeRequestField(source.Value);
                case RequestFieldType.CarId:
                    return new CarIdRequestField(source.Value);
                case RequestFieldType.ReasonForApplication:
                    return new ReasonForApplicationRequestField(source.Value);
                case RequestFieldType.RegisterNumber:
                    return new RegisterNumberRequestField(source.Value);
                case RequestFieldType.RequestReference:
                    return new RequestReferenceRequestField(source.Value);
                case RequestFieldType.RequesterEmail:
                    return new RequesterEmailRequestField(source.Value);
                case RequestFieldType.RequesterName:
                    return new RequesterNameRequestField(source.Value);
                case RequestFieldType.RequesterPhone:
                    return new RequesterPhoneRequestField(source.Value);
                case RequestFieldType.VinNumber:
                    return new VinNumberRequestField(source.Value);
                case RequestFieldType.Year:
                    return new YearRequestField(source.Value);
            }

            return null;
        }
    }
}