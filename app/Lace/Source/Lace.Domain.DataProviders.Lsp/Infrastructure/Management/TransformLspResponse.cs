﻿using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Extensions;

namespace Lace.Domain.DataProviders.Lsp.Infrastructure.Management
{
    public class TransformLspResponse : ITransformResponseFromDataProvider
    {
        public string Message { get; private set; }
      //  public IProvideDataFromLspDriversLicenseDecryption Result { get; private set; }

        public bool Continue { get; private set; }

        public TransformLspResponse(string response)
        {
            Continue = !string.IsNullOrWhiteSpace(response);
            Message = response;
        }

        public void Transform()
        {
            //var card = Message.XmlToObject<Dto.DrivingLicenseCard>();

            //Result = card == null
            //    ? null
            //    : new LspDriversLicenseDecryptionResponse(new DrivingLicenseCard(
            //        new IdentityDocument(card.IdentityDocument.Number, card.IdentityDocument.IdentityType),
            //        new Person(card.Person.Surname, card.Person.Initials, card.Person.DriverRestriction1,
            //            card.Person.DriverRestriction2, card.Person.DateOfBirth, card.Person.PreferenceLanguage,
            //            card.Person.Gender),
            //        new DrivingLicense(card.DrivingLicense.CertificateNumber, card.DrivingLicense.CountryOfIssue),
            //        new Card(card.Card.IssueNumber, card.Card.DateValidFrom, card.Card.DateValidUntil),
            //        new ProfessionalDrivingPermit(card.ProfessionalDrivingPermit.Category,
            //            card.ProfessionalDrivingPermit.DateValidUntil),
            //        new VehicleClass(card.VehicleClass1.Code, card.VehicleClass1.VehicleRestriction,
            //            card.VehicleClass1.FirstIssueDate),
            //        new VehicleClass(card.VehicleClass2.Code, card.VehicleClass2.VehicleRestriction,
            //            card.VehicleClass2.FirstIssueDate),
            //        new VehicleClass(card.VehicleClass3.Code, card.VehicleClass3.VehicleRestriction,
            //            card.VehicleClass3.FirstIssueDate),
            //        new VehicleClass(card.VehicleClass4.Code, card.VehicleClass4.VehicleRestriction,
            //            card.VehicleClass4.FirstIssueDate),
            //        card.Photo, card.Cellphone, card.EmailAddress), Message);
        }

        
    }
}
