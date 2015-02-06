﻿namespace Lace.Test.Helper.Fakes.Responses
{
    public class FakeSignioDecryptedDriversLicenseResponse
    {
        public static string GetDecryptedDriversLicenseXmlResponse()
        {
            return
                @"<DrivingLicenseCard xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">\n  <IdentityDocument>\n    <Number>8103155077088</Number>\n    <Type>02</Type>\n    <CountryOfIssue>ZA</CountryOfIssue>\n  </IdentityDocument>\n  <Person>\n    <Surname>JORDAAN</Surname>\n    <Initials>L</Initials>\n    <DriverRestriction1>0</DriverRestriction1>\n    <DriverRestriction2>0</DriverRestriction2>\n    <DateOfBirth>15/03/1981</DateOfBirth>\n    <PreferenceLanguage />\n    <Gender>MALE</Gender>\n  </Person>\n  <DrivingLicense>\n    <CertificateNumber>409900036V1K</CertificateNumber>\n    <CountryOfIssue>ZA</CountryOfIssue>\n  </DrivingLicense>\n  <Card>\n    <IssueNumber>01</IssueNumber>\n    <DateValidFrom>19/07/2008</DateValidFrom>\n    <DateValidUntil>18/07/2013</DateValidUntil>\n  </Card>\n  <ProfessionalDrivingPermit>\n    <Category />\n    <DateValidUntil />\n  </ProfessionalDrivingPermit>\n  <VehicleClass1>\n    <Code>B</Code>\n    <VehicleRestriction>0</VehicleRestriction>\n    <FirstIssueDate>17/07/2008</FirstIssueDate>\n  </VehicleClass1>\n  <VehicleClass2>\n    <Code />\n    <VehicleRestriction />\n    <FirstIssueDate />\n  </VehicleClass2>\n  <VehicleClass3>\n    <Code />\n    <VehicleRestriction />\n    <FirstIssueDate />\n  </VehicleClass3>\n  <VehicleClass4>\n    <Code />\n    <VehicleRestriction />\n    <FirstIssueDate />\n  </VehicleClass4>\n  <Photo>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AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</Photo>\n</DrivingLicenseCard>";
        }
    }
}
