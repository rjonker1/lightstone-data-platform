using System.Linq;
using Api.Domain.Verification.Core.Contracts;
using Api.Domain.Verification.Infrastructure.Dto;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;

namespace Api.Domain.Verification.Infrastructure.Services
{
    public class DriversLicenseVerificationService : ICallDriversLicenseVerification
    {
        private readonly IEntryPoint _entryPointService;

        public DriversLicenseVerificationService(IEntryPoint entryPointService)
        {
            _entryPointService = entryPointService;
        }

        public IHaveDriversLicenseResponse DecodeDriversLincenseFromScan(ILaceRequest request)
        {
            var responses = _entryPointService.GetResponsesFromLace(request);

            if (responses == null || !responses.Any())
                return new DriversLicenseResponseDto();

            var response = responses[0];

            if (response == null || response.Response.SignioDriversLicenseDecryptionResponse == null)
                return new DriversLicenseResponseDto();

            var detail = response.Response.SignioDriversLicenseDecryptionResponse;

            if (detail.DrivingLicense == null)
                return new DriversLicenseResponseDto();

            return new DriversLicenseResponseDto(new DrivingLicenseCard(
                new IdentityDocument(detail.DrivingLicense.IdentityDocument.Number,
                    detail.DrivingLicense.IdentityDocument.IdentityType),
                new Person(detail.DrivingLicense.Person.Surname, detail.DrivingLicense.Person.Initials,
                    detail.DrivingLicense.Person.DriverRestriction1, detail.DrivingLicense.Person.DriverRestriction2,
                    detail.DrivingLicense.Person.DateOfBirth, detail.DrivingLicense.Person.PreferenceLanguage,
                    detail.DrivingLicense.Person.Gender),
                new DrivingLicense(detail.DrivingLicense.DrivingLicense.CertificateNumber,
                    detail.DrivingLicense.DrivingLicense.CountryOfIssue),
                new Card(detail.DrivingLicense.Card.IssueNumber, detail.DrivingLicense.Card.DateValidFrom,
                    detail.DrivingLicense.Card.DateValidUntil),
                new ProfessionalDrivingPermit(detail.DrivingLicense.ProfessionalDrivingPermit.Category,
                    detail.DrivingLicense.ProfessionalDrivingPermit.DateValidUntil),
                new VehicleClass(detail.DrivingLicense.VehicleClass1.Code,
                    detail.DrivingLicense.VehicleClass1.VehicleRestriction,
                    detail.DrivingLicense.VehicleClass1.FirstIssueDate),
                new VehicleClass(detail.DrivingLicense.VehicleClass2.Code,
                    detail.DrivingLicense.VehicleClass2.VehicleRestriction,
                    detail.DrivingLicense.VehicleClass2.FirstIssueDate),
                new VehicleClass(detail.DrivingLicense.VehicleClass3.Code,
                    detail.DrivingLicense.VehicleClass3.VehicleRestriction,
                    detail.DrivingLicense.VehicleClass3.FirstIssueDate),
                new VehicleClass(detail.DrivingLicense.VehicleClass4.Code,
                    detail.DrivingLicense.VehicleClass4.VehicleRestriction,
                    detail.DrivingLicense.VehicleClass4.FirstIssueDate),
                detail.DrivingLicense.Photo, detail.DrivingLicense.Cellphone, detail.DrivingLicense.EmailAddress),
                detail.DecodedData);
        }

    }
}