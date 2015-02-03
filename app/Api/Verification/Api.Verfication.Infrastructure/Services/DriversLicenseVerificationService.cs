﻿using Api.Verfication.Core.Contracts;
using Api.Verfication.Infrastructure.Dto;

namespace Api.Verfication.Infrastructure.Services
{
    public class DriversLicenseVerificationService : ICallDriversLicenseVerification
    {
        public IHaveDriversLicenseResponse DecodeDriversLincenseFromScan(IHaveDriversLicenseRequest request)
        {
            var driversLicense = new DrivingLicenseCard(new IdentityDocument("5110245084084", "02"),
                new Person("Louw", "VJ", "None", "Glasses/Contact Lenses", "1951-10-24 00:00:00.000", "", "Male"),
                new DrivingLicense("605400055T2H", "ZA"),
                new Card("01", "2012-10-09 00:00:00.000", "2017-11-28 00:00:00.000"),
                new ProfessionalDrivingPermit("N/A", "2017-11-28 00:00:00.000"),
                new VehicleClass("A", "None", "1999-12-20 00:00:00.000"),
                new VehicleClass("EB", "None", "1999-12-20 00:00:00.000"), null, null,
                @"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9TQB0P21KKwgT6migD//2QAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA="
                , null, null);

            return new DriversLicenseResponseDto(driversLicense, string.Empty);
        }

    }
}