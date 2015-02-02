using System;
using Api.Scans.Verfication.Infrastructure.Dto;

namespace Api.Scans.Verfication.Core.Contracts
{
    public interface ICallDriversLicenseVerification
    {
        //DrivingLicenseCard DecodeDriversLincenseFromScan(string scanData, string registrationCode, string username,
        //    Guid userId, out string decodedData);
        DriversLicenseResponseDto DecodeDriversLincenseFromScan(DriversLicenseRequestDto request);
    }
}
