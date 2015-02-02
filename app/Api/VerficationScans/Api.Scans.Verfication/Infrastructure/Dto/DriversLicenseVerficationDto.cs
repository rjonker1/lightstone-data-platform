using System;

namespace Api.Scans.Verfication.Infrastructure.Dto
{

    public class DriversLicenseRequestDto
    {
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

    public class DriversLicenseResponseDto
    {
        public DriversLicenseResponseDto(DrivingLicenseCard driversLicense, string decodedData)
        {
            DrivingLicense = driversLicense;
            DecodedData = decodedData;
        }

        public DrivingLicenseCard DrivingLicense { get; private set; }
        public string DecodedData { get; private set; }
    }

    public class DrivingLicenseCard
    {
        public DrivingLicenseCard(IdentityDocument identityDocument, Person person, DrivingLicense drivingLicense, Card card,
            ProfessionalDrivingPermit professionalDrivingPermit, VehicleClass vehicleClass1, VehicleClass vehicleClass2,
            VehicleClass vehicleClass3, VehicleClass vehicleClass4, string photo, string cellphone, string emailAddress)
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

        public IdentityDocument IdentityDocument { get; private set; }
        public Person Person { get; private set; }
        public DrivingLicense DrivingLicense { get; private set; }
        public Card Card { get; private set; }
        public ProfessionalDrivingPermit ProfessionalDrivingPermit { get; private set; }
        public VehicleClass VehicleClass1 { get; private set; }
        public VehicleClass VehicleClass2 { get; private set; }
        public VehicleClass VehicleClass3 { get; private set; }
        public VehicleClass VehicleClass4 { get; private set; }
        public string Photo { get; private set; }
        public string Cellphone { get; private set; }
        public string EmailAddress { get; private set; }
    }
    public class IdentityDocument
    {
        public IdentityDocument(string number, string type)
        {
            Number = number;
            Type = type;
        }

        public string Number { get; private set; }
        public string Type { get; private set; }
    }

    public class Person
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

    public class DrivingLicense
    {
        public DrivingLicense(string certificateNumber, string countryOfIssue)
        {
            CertificateNumber = certificateNumber;
            CountryOfIssue = countryOfIssue;
        }

        public string CertificateNumber { get; private set; }
        public string CountryOfIssue { get; private set; }
    }

    public class Card
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

    public class ProfessionalDrivingPermit
    {
        public ProfessionalDrivingPermit(string category, string dateValidUntil)
        {
            Category = category;
            DateValidUntil = dateValidUntil;
        }

        public string Category { get; private set; }
        public string DateValidUntil { get; private set; }
    }

    public class VehicleClass
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