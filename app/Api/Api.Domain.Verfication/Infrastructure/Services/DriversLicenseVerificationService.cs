using System.Linq;
using Api.Domain.Verification.Core.Contracts;
using Api.Domain.Verification.Infrastructure.Dto;
using Lace.Domain.Core.Contracts.DataProviders;
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

        public IHaveDriversLicenseResponse DecodeDriversLincenseFromScan(IPointToLaceRequest request)
        {
            var responses = _entryPointService.GetResponsesFromLace(new [] {request});

            if (responses == null || !responses.Any())
                return new DriversLicenseResponseDto();

            if (!responses.OfType<IProvideDataFromSignioDriversLicenseDecryption>().Any() ||
                responses.OfType<IProvideDataFromSignioDriversLicenseDecryption>().First() == null)
                return new DriversLicenseResponseDto();

            var response = responses.OfType<IProvideDataFromSignioDriversLicenseDecryption>().First();

            if (response.DrivingLicense == null)
                return new DriversLicenseResponseDto();

            return new DriversLicenseResponseDto(new DrivingLicenseCard(
                new IdentityDocument(response.DrivingLicense.IdentityDocument.Number,
                    response.DrivingLicense.IdentityDocument.IdentityType),
                new Person(response.DrivingLicense.Person.Surname, response.DrivingLicense.Person.Initials,
                    response.DrivingLicense.Person.DriverRestriction1, response.DrivingLicense.Person.DriverRestriction2,
                    response.DrivingLicense.Person.DateOfBirth, response.DrivingLicense.Person.PreferenceLanguage,
                    response.DrivingLicense.Person.Gender),
                new DrivingLicense(response.DrivingLicense.DrivingLicense.CertificateNumber,
                    response.DrivingLicense.DrivingLicense.CountryOfIssue),
                new Card(response.DrivingLicense.Card.IssueNumber, response.DrivingLicense.Card.DateValidFrom,
                    response.DrivingLicense.Card.DateValidUntil),
                new ProfessionalDrivingPermit(response.DrivingLicense.ProfessionalDrivingPermit.Category,
                    response.DrivingLicense.ProfessionalDrivingPermit.DateValidUntil),
                new VehicleClass(response.DrivingLicense.VehicleClass1.Code,
                    response.DrivingLicense.VehicleClass1.VehicleRestriction,
                    response.DrivingLicense.VehicleClass1.FirstIssueDate),
                new VehicleClass(response.DrivingLicense.VehicleClass2.Code,
                    response.DrivingLicense.VehicleClass2.VehicleRestriction,
                    response.DrivingLicense.VehicleClass2.FirstIssueDate),
                new VehicleClass(response.DrivingLicense.VehicleClass3.Code,
                    response.DrivingLicense.VehicleClass3.VehicleRestriction,
                    response.DrivingLicense.VehicleClass3.FirstIssueDate),
                new VehicleClass(response.DrivingLicense.VehicleClass4.Code,
                    response.DrivingLicense.VehicleClass4.VehicleRestriction,
                    response.DrivingLicense.VehicleClass4.FirstIssueDate),
                response.DrivingLicense.Photo, response.DrivingLicense.Cellphone, response.DrivingLicense.EmailAddress),
                response.DecodedData);
        }

    }
}