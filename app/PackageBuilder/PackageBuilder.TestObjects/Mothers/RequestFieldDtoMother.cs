﻿using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Enums.Requests;
using PackageBuilder.TestObjects.Builders;

namespace PackageBuilder.TestObjects.Mothers
{
    public class RequestFieldDtoMother
    {
        public static DataProviderFieldItemDto CarId
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("CarId", "Car Id", "Definition")
                    .With(((int)RequestFieldType.CarId).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Year
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Year", "Year", "Definition")
                    .With(((int)RequestFieldType.Year).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Make
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Make", "Make", "Definition")
                    .With(((int)RequestFieldType.Make).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto VinNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("VinNumber", "VinNumber", "Definition")
                    .With(((int)RequestFieldType.VinNumber).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RegisterNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RegisterNumber", "RegisterNumber", "Definition")
                    .With(((int)RequestFieldType.RegisterNumber).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto EngineNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("EngineNumber", "EngineNumber", "Definition")
                    .With(((int)RequestFieldType.EngineNumber).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ChassisNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ChassisNumber", "ChassisNumber", "Definition")
                    .With(((int)RequestFieldType.ChassisNumber).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto LicenseNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("LicenseNumber", "LicenseNumber", "Definition")
                    .With(((int)RequestFieldType.LicenseNumber).ToString())
                    .Build();
            }
        }
    }
}