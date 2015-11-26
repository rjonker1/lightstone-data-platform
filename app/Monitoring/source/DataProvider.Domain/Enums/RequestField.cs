using System.Runtime.Serialization;

namespace DataProvider.Domain.Enums
{
    public enum RequestFieldType
    {
        [EnumMember(Value = "Vin Number")]
        VinNumber = 0,
        [EnumMember(Value = "License Number")]
        LicenceNumber = 1,
        [EnumMember(Value = "Car Id")]
        CarId = 2,
        [EnumMember(Value = "Year")]
        Year = 3,
        [EnumMember(Value = "ID Number")]
        IdentityNumber = 4,
        [EnumMember(Value = "DLi Scan")]
        ScanData = 5,
        [EnumMember(Value = "Reg Number")]
        RegisterNumber = 7,
        [EnumMember(Value = "Undefined")]
        Undefined = 99
    }
}

//{
//    public enum RequestFieldType
//    {
//        VinNumber = 0,
//        LicenseNumber = 1,
//        RegisterNumber = 2,
//        EngineNumber = 3,
//        ChassisNumber = 4,
//        ApplicantName = 5,
//        Label = 6,
//        Make = 7,
//        CarId = 8,
//        Year = 9,
//        ReasonForApplication = 10,
//        RequesterName = 11,
//        RequesterEmail = 12,
//        RequesterPhone = 13,
//        RequestReference = 14,
//        IdentityNumber = 15,
//        FirstName = 16,
//        Surname = 17,
//        CompanyName = 18,
//        CompanyRegistrationNumber = 19,
//        CompanyVatNumber = 20,
//        ScanData = 21,
//        RegistrationCode = 22,
//        UserName = 23,
//        UserId = 24,
//        PhoneNumber = 25,
//        EmailAddress = 26,
//        AccessKey = 27,
//        AccountNumber = 28
//    }