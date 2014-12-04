using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Models;

namespace Lace.Domain.Core.Entities
{
    public class IvidResponse : IProvideDataFromIvid, IBuildIvidResponse
    {
        private const string NotAvailableError = "Error - Not Available";

        public void Build(string statusMessage, string reference, string license, string registration,
            string registrationDate, string vin, string engine,
            string displacement, string tare)
        {
            StatusMessage = CheckPartial(statusMessage);
            Reference = CheckPartial(reference);
            License = CheckPartial(license);
            Registration = CheckPartial(registration);
            RegistrationDate = CheckPartial(registrationDate);
            Vin = CheckPartial(vin);
            Engine = CheckPartial(engine);
            Displacement = CheckPartial(displacement);
            Tare = CheckPartial(tare);
        }

        public void SetErrorFlag(bool check)
        {
            HasErrors |= check;
        }

        public void SetHasIssuesFlag(bool check)
        {
            HasIssues |= check;
        }

        public void SetMake(IvidCodePair pair)
        {
            MakeCode = pair.Code;
            MakeDescription = pair.Description;
        }

        public void SetModel(IvidCodePair pair)
        {
            ModelCode = pair.Code;
            ModelDescription = pair.Description;
        }

        public void SetColor(IvidCodePair pair)
        {
            ColourCode = pair.Code;
            ColourDescription = pair.Description;
        }

        public void SetDriven(IvidCodePair pair)
        {
            DrivenCode = pair.Code;
            DrivenDescription = pair.Description;
        }

        public void SetCategory(IvidCodePair pair)
        {
            CategoryCode = pair.Code;
            CategoryDescription = pair.Description;
        }

        public void SetDescription(IvidCodePair pair)
        {
            DescriptionCode = pair.Code;
            Description = pair.Description;
        }

        public void SetEconomicSector(IvidCodePair pair)
        {
            EconomicSectorCode = pair.Code;
            EconomicSectorDescription = pair.Description;
        }

        public void SetLifeStatus(IvidCodePair pair)
        {
            LifeStatusCode = pair.Code;
            LifeStatusDescription = pair.Description;
        }

        public void SetSapMark(IvidCodePair pair)
        {
            SapMarkCode = pair.Code;
            SapMarkDescription = pair.Description;
        }

        public void BuildSpecificInformation()
        {
            SpecificInformation = new VehicleSpecificInformation("Odometer Not Available", ColourDescription,
                Registration, Vin, License, Engine, CategoryDescription);
        }

        public void SetCarFullName()
        {
            var carFullName = string.Format("{0} {1}", MakeDescription, ModelDescription);
            CarFullname = string.IsNullOrEmpty(carFullName) ? null : carFullName;
        }

        private string CheckPartial(string value)
        {
            if (HasErrors && string.IsNullOrWhiteSpace(value))
            {
                value = NotAvailableError;
            }
            return value;
        }


        public IProvideVehicleSpecificInformation SpecificInformation { get; private set; }

        public string StatusMessage { get; private set; }

        public string Reference { get; private set; }

        public string License { get; private set; }

        public string Registration { get; private set; }

        public string RegistrationDate { get; private set; }

        public string Vin { get; private set; }

        public string Engine { get; private set; }

        public string Displacement { get; private set; }

        public string Tare { get; private set; }

        public string MakeCode { get; private set; }

        public string MakeDescription { get; private set; }

        public string ModelCode { get; private set; }

        public string ModelDescription { get; private set; }

        public string ColourCode { get; private set; }

        public string ColourDescription { get; private set; }

        public string DrivenCode { get; private set; }

        public string DrivenDescription { get; private set; }

        public string CategoryCode { get; private set; }

        public string CategoryDescription { get; private set; }

        public string DescriptionCode { get; private set; }

        public string Description { get; private set; }

        public string EconomicSectorCode { get; private set; }

        public string EconomicSectorDescription { get; private set; }

        public string LifeStatusCode { get; private set; }

        public string LifeStatusDescription { get; private set; }

        public string SapMarkCode { get; private set; }

        public string SapMarkDescription { get; private set; }

        public bool HasIssues { get; private set; }

        public bool HasErrors { get; private set; }

        public string CarFullname { get; private set; }

    }
}
