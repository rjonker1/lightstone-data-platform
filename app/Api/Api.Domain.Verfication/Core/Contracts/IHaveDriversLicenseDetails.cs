using System;

namespace Api.Domain.Verification.Core.Contracts
{
    public interface IHaveVehicleClass
    {
        string Code { get; }
        string VehicleRestriction { get; }
        string FirstIssueDate { get; }
    }

    public interface IHaveProfessionalDrivingPermit
    {
        string Category { get; }
        string DateValidUntil { get; }
    }

    public interface IHaveCard
    {
        string IssueNumber { get; }
        string DateValidFrom { get; }
        string DateValidUntil { get; }
    }

    public interface IHaveDrivingLicense
    {
        string CertificateNumber { get; }
        string CountryOfIssue { get; }
    }

    public interface IHavePerson
    {
        string Surname { get; }
        string Initials { get; }
        string DriverRestriction1 { get; }
        string DriverRestriction2 { get; }
        string DateOfBirth { get; }
        string PreferenceLanguage { get; }
        string Gender { get; }
    }

    public interface IHaveIdentityDocument
    {
        string Number { get; }
        string Type { get; }
    }

    public interface IHaveDrivingLicenseCard
    {
        IHaveIdentityDocument IdentityDocument { get; }
        IHavePerson Person { get; }
        IHaveDrivingLicense DrivingLicense { get; }
        IHaveCard Card { get; }
        IHaveProfessionalDrivingPermit ProfessionalDrivingPermit { get; }
        IHaveVehicleClass VehicleClass1 { get; }
        IHaveVehicleClass VehicleClass2 { get; }
        IHaveVehicleClass VehicleClass3 { get; }
        IHaveVehicleClass VehicleClass4 { get; }
        string Photo { get; }
        string Cellphone { get; }
        string EmailAddress { get; }
    }

    public interface IHaveDriversLicenseResponse
    {
        IHaveDrivingLicenseCard DrivingLicense { get; }
        string DecodedData { get; }
    }

    public interface IHaveDriversLicenseRequest
    {
        string ScanData { get; }
        string RegistrationCode { get; }
        string Username { get; }
        Guid UserId { get; }
    }
}
