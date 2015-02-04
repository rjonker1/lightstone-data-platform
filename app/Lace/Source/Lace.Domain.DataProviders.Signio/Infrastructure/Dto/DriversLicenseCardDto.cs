using System;

namespace Lace.Domain.DataProviders.Signio.DriversLicense.Infrastructure.Dto
{
    [Serializable]
    public class DrivingLicenseCard
    {
        public DrivingLicenseCard()
        {

        }

        public DrivingLicenseCard(IdentityDocument identityDocument, Person person,
            DrivingLicense drivingLicense, Card card,
            ProfessionalDrivingPermit professionalDrivingPermit, VehicleClass vehicleClass1,
            VehicleClass vehicleClass2,
            VehicleClass vehicleClass3, VehicleClass vehicleClass4, string photo,
            string cellphone, string emailAddress)
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

        public IdentityDocument IdentityDocument { get; set; }
        public Person Person { get; set; }
        public DrivingLicense DrivingLicense { get; set; }
        public Card Card { get; set; }
        public ProfessionalDrivingPermit ProfessionalDrivingPermit { get; set; }
        public VehicleClass VehicleClass1 { get; set; }
        public VehicleClass VehicleClass2 { get; set; }
        public VehicleClass VehicleClass3 { get; set; }
        public VehicleClass VehicleClass4 { get; set; }
        public string Photo { get; set; }
        public string Cellphone { get; set; }
        public string EmailAddress { get; set; }
    }

    [Serializable]
    public class IdentityDocument
    {
        public IdentityDocument()
        {

        }
        public IdentityDocument(string number, string identityType)
        {
            Number = number;
            IdentityType = identityType;
        }
        public string Number { get; set; }
        public string IdentityType { get; set; }


        public System.Type Type
        {
            get { return GetType(); }
        }


        public string TypeName
        {
            get { return GetType().Name; }
        }
    }

    [Serializable]
    public class Person
    {
        public Person()
        {

        }

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
        public string Surname { get; set; }
        public string Initials { get; set; }
        public string DriverRestriction1 { get; set; }
        public string DriverRestriction2 { get; set; }
        public string DateOfBirth { get; set; }
        public string PreferenceLanguage { get; set; }
        public string Gender { get; set; }
    }

    [Serializable]
    public class DrivingLicense
    {
        public DrivingLicense()
        {

        }

        public DrivingLicense(string certificateNumber, string countryOfIssue)
        {
            CertificateNumber = certificateNumber;
            CountryOfIssue = countryOfIssue;
        }
        public string CertificateNumber { get; set; }
        public string CountryOfIssue { get; set; }
    }

    [Serializable]
    public class Card
    {
        public Card()
        {

        }


        public Card(string issueNumber, string dateValdidFrom, string dateValidUntil)
        {
            IssueNumber = issueNumber;
            DateValidFrom = dateValdidFrom;
            DateValidUntil = dateValidUntil;
        }
        public string IssueNumber { get; set; }
        public string DateValidFrom { get; set; }
        public string DateValidUntil { get; set; }
    }

    [Serializable]
    public class ProfessionalDrivingPermit
    {
        public ProfessionalDrivingPermit()
        {

        }

        public ProfessionalDrivingPermit(string category, string dateValidUntil)
        {
            Category = category;
            DateValidUntil = dateValidUntil;
        }
        public string Category { get; set; }
        public string DateValidUntil { get; set; }
    }

    [Serializable]
    public class VehicleClass
    {
        public VehicleClass()
        {

        }

        public VehicleClass(string code, string vehicleRestriction, string firstIssueDate)
        {
            Code = code;
            VehicleRestriction = vehicleRestriction;
            FirstIssueDate = firstIssueDate;
        }
        public string Code { get; set; }
        public string VehicleRestriction { get; set; }
        public string FirstIssueDate { get; set; }
    }
}
