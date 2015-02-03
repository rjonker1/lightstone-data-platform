using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.DriversLicense;

namespace Lace.Domain.Core.Entities
{
    [Serializable]
    [DataContract]
    public class DrivingLicenseCard : IRespondWithDriversLicenseCard
    {
        public DrivingLicenseCard()
        {
            
        }

        public DrivingLicenseCard(IRespondWithIdentityDocument identityDocument, IRespondWithPerson person,
            IRespondWithDrivingLicense drivingLicense, IRespondWithCard card,
            IRespondWithProfessionalDrivingPermit professionalDrivingPermit, IRespondWithVehicleClass vehicleClass1,
            IRespondWithVehicleClass vehicleClass2,
            IRespondWithVehicleClass vehicleClass3, IRespondWithVehicleClass vehicleClass4, string photo,
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

        [DataMember]
        public IRespondWithIdentityDocument IdentityDocument { get; private set; }

        [DataMember]
        public IRespondWithPerson Person { get; private set; }

        [DataMember]
        public IRespondWithDrivingLicense DrivingLicense { get; private set; }

        [DataMember]
        public IRespondWithCard Card { get; private set; }

        [DataMember]
        public IRespondWithProfessionalDrivingPermit ProfessionalDrivingPermit { get; private set; }

        [DataMember]
        public IRespondWithVehicleClass VehicleClass1 { get; private set; }

        [DataMember]
        public IRespondWithVehicleClass VehicleClass2 { get; private set; }

        [DataMember]
        public IRespondWithVehicleClass VehicleClass3 { get; private set; }

        [DataMember]
        public IRespondWithVehicleClass VehicleClass4 { get; private set; }

        [DataMember]
        public string Photo { get; private set; }

        [DataMember]
        public string Cellphone { get; private set; }

        [DataMember]
        public string EmailAddress { get; private set; }

        [DataMember]
        public System.Type Type
        {
            get { return GetType(); }
        }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
        }
    }

    [Serializable]
    [DataContract]
    public class IdentityDocument : IRespondWithIdentityDocument
    {
        public IdentityDocument()
        {
            
        }
        public IdentityDocument(string number, string identityType)
        {
            Number = number;
            IdentityType = identityType;
        }

        [DataMember]
        public string Number { get; private set; }
        [DataMember]
        public string IdentityType { get; private set; }

        [DataMember]
        public System.Type Type
        {
            get { return GetType(); }
        }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
        }
    }

    [Serializable]
    [DataContract]
    public class Person : IRespondWithPerson
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

        [DataMember]
        public string Surname { get; private set; }
        [DataMember]
        public string Initials { get; private set; }
        [DataMember]
        public string DriverRestriction1 { get; private set; }
        [DataMember]
        public string DriverRestriction2 { get; private set; }
        [DataMember]
        public string DateOfBirth { get; private set; }
        [DataMember]
        public string PreferenceLanguage { get; private set; }
        [DataMember]
        public string Gender { get; private set; }

        [DataMember]
        public Type Type
        {
            get { return GetType(); }
        }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
        }
    }

    [Serializable]
    [DataContract]
    public class DrivingLicense : IRespondWithDrivingLicense
    {
        public DrivingLicense()
        {
            
        }

        public DrivingLicense(string certificateNumber, string countryOfIssue)
        {
            CertificateNumber = certificateNumber;
            CountryOfIssue = countryOfIssue;
        }

        [DataMember]
        public string CertificateNumber { get; private set; }
        [DataMember]
        public string CountryOfIssue { get; private set; }

        [DataMember]
        public System.Type Type
        {
            get { return GetType(); }
        }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
        }
    }

    [Serializable]
    [DataContract]
    public class Card : IRespondWithCard
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

        [DataMember]
        public string IssueNumber { get; private set; }
        [DataMember]
        public string DateValidFrom { get; private set; }
        [DataMember]
        public string DateValidUntil { get; private set; }

        [DataMember]
        public System.Type Type
        {
            get { return GetType(); }
        }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
        }
    }

    [Serializable]
    [DataContract]
    public class ProfessionalDrivingPermit : IRespondWithProfessionalDrivingPermit
    {
        public ProfessionalDrivingPermit()
        {
            
        }

        public ProfessionalDrivingPermit(string category, string dateValidUntil)
        {
            Category = category;
            DateValidUntil = dateValidUntil;
        }

        [DataMember]
        public string Category { get; private set; }
        [DataMember]
        public string DateValidUntil { get; private set; }

        [DataMember]
        public System.Type Type
        {
            get { return GetType(); }
        }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
        }
    }

    [Serializable]
    [DataContract]
    public class VehicleClass : IRespondWithVehicleClass
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

        [DataMember]
        public string Code { get; private set; }
        [DataMember]
        public string VehicleRestriction { get; private set; }
        [DataMember]
        public string FirstIssueDate { get; private set; }

        [DataMember]
        public System.Type Type
        {
            get { return GetType(); }
        }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
        }
    }
}
