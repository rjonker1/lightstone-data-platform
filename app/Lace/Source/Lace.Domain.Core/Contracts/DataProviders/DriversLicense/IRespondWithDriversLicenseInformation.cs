using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.DriversLicense
{
    public interface IRespondWithDriversLicenseCard : IProvideType
    {
        IRespondWithIdentityDocument IdentityDocument { get; }
        IRespondWithPerson Person { get; }
        IRespondWithDrivingLicense DrivingLicense { get; }
        IRespondWithCard Card { get; }
        IRespondWithProfessionalDrivingPermit ProfessionalDrivingPermit { get; }
        IRespondWithVehicleClass VehicleClass1 { get; }
        IRespondWithVehicleClass VehicleClass2 { get; }
        IRespondWithVehicleClass VehicleClass3 { get; }
        IRespondWithVehicleClass VehicleClass4 { get; }
        string Photo { get; }
        string Cellphone { get; }
        string EmailAddress { get; }
    }

    public interface IRespondWithIdentityDocument : IProvideType
    {
        string Number { get;}
        string IdentityType { get; }
    }

    public interface IRespondWithPerson : IProvideType
    {
        string Surname { get;}
        string Initials { get;}
        string DriverRestriction1 { get;}
        string DriverRestriction2 { get;}
        string DateOfBirth { get;}
        string PreferenceLanguage { get;}
        string Gender { get;}
    }

    public interface IRespondWithDrivingLicense : IProvideType
    {
        string CertificateNumber { get; }
        string CountryOfIssue { get; }
    }

    public interface IRespondWithCard : IProvideType
    {
        string IssueNumber { get; }
        string DateValidFrom { get; }
        string DateValidUntil { get; }
    }

    public interface IRespondWithProfessionalDrivingPermit : IProvideType
    {
        string Category { get; }
        string DateValidUntil { get; }
    }

    public interface IRespondWithVehicleClass : IProvideType
    {
        string Code { get; }
        string VehicleRestriction { get; }
        string FirstIssueDate { get; }
    }
}
