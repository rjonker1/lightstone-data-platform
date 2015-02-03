using System;
using Api.Verfication.Core.Contracts;

namespace Api.Verfication.Infrastructure.Dto
{

    public class DriversLicenseRequestDto : IHaveDriversLicenseRequest
    {
        public DriversLicenseRequestDto()
        {
            
        }
        public DriversLicenseRequestDto(string scanData, string registrationCode,
            string username, Guid userId)
        {
            ScanData = scanData;
            RegistrationCode = registrationCode;
            Username = username;
            UserId = userId;
        }

        public string ScanData { get; private set; }
        public string RegistrationCode { get; private set; }
        public string Username { get; private set; }
        public Guid UserId { get; private set; }
    }

    public class DriversLicenseResponseDto : IHaveDriversLicenseResponse
    {
        public DriversLicenseResponseDto()
        {
            
        }

        public DriversLicenseResponseDto(IHaveDrivingLicenseCard driversLicense, string decodedData)
        {
            DrivingLicense = driversLicense;
            DecodedData = decodedData;
        }

        public IHaveDrivingLicenseCard DrivingLicense { get; private set; }
        public string DecodedData { get; private set; }
    }

    public class DrivingLicenseCard : IHaveDrivingLicenseCard
    {

        public DrivingLicenseCard(IHaveIdentityDocument identityDocument, IHavePerson person, IHaveDrivingLicense drivingLicense, IHaveCard card,
            IHaveProfessionalDrivingPermit professionalDrivingPermit, IHaveVehicleClass vehicleClass1, IHaveVehicleClass vehicleClass2,
            IHaveVehicleClass vehicleClass3, IHaveVehicleClass vehicleClass4, string photo, string cellphone, string emailAddress)
        {
            IdentityDocument = identityDocument;
            Person = person;
            DrivingLicense = drivingLicense;
            Card = card;
            ProfessionalDrivingPermit = professionalDrivingPermit;
            VehicleClass1 = vehicleClass1;
            VehicleClass2 = vehicleClass2;
            VehicleClass3 = vehicleClass3;
            VehicleClass4 = vehicleClass4;
            Photo = photo;
            Cellphone = cellphone;
            EmailAddress = emailAddress;
        }

        public IHaveIdentityDocument IdentityDocument { get; private set; }
        public IHavePerson Person { get; private set; }
        public IHaveDrivingLicense DrivingLicense { get; private set; }
        public IHaveCard Card { get; private set; }
        public IHaveProfessionalDrivingPermit ProfessionalDrivingPermit { get; private set; }
        public IHaveVehicleClass VehicleClass1 { get; private set; }
        public IHaveVehicleClass VehicleClass2 { get; private set; }
        public IHaveVehicleClass VehicleClass3 { get; private set; }
        public IHaveVehicleClass VehicleClass4 { get; private set; }
        public string Photo { get; private set; }
        public string Cellphone { get; private set; }
        public string EmailAddress { get; private set; }
    }
    public class IdentityDocument : IHaveIdentityDocument
    {
        public IdentityDocument(string number, string type)
        {
            Number = number;
            Type = type;
        }

        public string Number { get; private set; }
        public string Type { get; private set; }
    }

    public class Person : IHavePerson
    {
        public Person(string surname, string initials, string driversRestriction1, string driversRestriction2,
            string dateOfBirth, string preferenceLanguage, string gender)
        {
            Surname = surname;
            Initials = initials;
            DriverRestriction1 = driversRestriction1;
            DriverRestriction2 = driversRestriction2;
            DateOfBirth = dateOfBirth;
            PreferenceLanguage = preferenceLanguage;
            Gender = gender;
        }

        public string Surname { get; private set; }
        public string Initials { get; private set; }
        public string DriverRestriction1 { get; private set; }
        public string DriverRestriction2 { get; private set; }
        public string DateOfBirth { get; private set; }
        public string PreferenceLanguage { get; private set; }
        public string Gender { get; private set; }
    }

    public class DrivingLicense : IHaveDrivingLicense
    {
        public DrivingLicense(string certificateNumber, string countryOfIssue)
        {
            CertificateNumber = certificateNumber;
            CountryOfIssue = countryOfIssue;
        }

        public string CertificateNumber { get; private set; }
        public string CountryOfIssue { get; private set; }
    }

    public class Card : IHaveCard
    {
        public Card(string issueNumber, string dateValdidFrom, string dateValidUntil)
        {
            IssueNumber = issueNumber;
            DateValidFrom = dateValdidFrom;
            DateValidUntil = dateValidUntil;
        }

        public string IssueNumber { get; private set; }
        public string DateValidFrom { get; private set; }
        public string DateValidUntil { get; private set; }
    }

    public class ProfessionalDrivingPermit : IHaveProfessionalDrivingPermit
    {
        public ProfessionalDrivingPermit(string category, string dateValidUntil)
        {
            Category = category;
            DateValidUntil = dateValidUntil;
        }

        public string Category { get; private set; }
        public string DateValidUntil { get; private set; }
    }

    public class VehicleClass : IHaveVehicleClass
    {
        public VehicleClass(string code, string vehicleRestriction, string firstIssueDate)
        {
            Code = code;
            VehicleRestriction = vehicleRestriction;
            FirstIssueDate = firstIssueDate;
        }

        public string Code { get; private set; }
        public string VehicleRestriction { get; private set; }
        public string FirstIssueDate { get; private set; }
    }

    
}