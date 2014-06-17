using Lace.Models.Ivid.Dto;
using Lace.Source.Ivid.IvidServiceReference;

namespace Lace.Source.Ivid.Transform
{
    public class TransformIvidResponse : ITransform
    {
        public HpiStandardQueryResponse Message { get; private set; }
        public IvidResponse Result { get; private set; }

        public bool Continue { get; private set; }

        public TransformIvidResponse(HpiStandardQueryResponse response)
        {
            Continue = response != null;
            Result = Continue ? new IvidResponse() : null;
            Message = response;
        }

        public void Transform()
        {
            Result.HasErrors = Message.partialResponse;
            Result.StatusMessage = CheckPartialResults(Message.ividQueryResult.ToString());
            Result.Reference = CheckPartialResults(Message.IvidReference);
            Result.License = CheckPartialResults(Message.licenceNumber);
            Result.Registration = CheckPartialResults(Message.registerNumber);
            Result.RegistrationDate = CheckPartialResults(Message.registrationDate);
            Result.Vin = CheckPartialResults(Message.vin);
            Result.Engine = CheckPartialResults(Message.engineNumber);
            Result.Displacement = CheckPartialResults(Message.engineDisplacement);
            Result.Tare = CheckPartialResults(Message.tare);
            Result.MakeCode = CreatePair(Message.make).Code;
            Result.MakeDescription = CreatePair(Message.make).Description;
            Result.ModelCode = CreatePair(Message.model).Code;
            Result.ModelDescription = CreatePair(Message.model).Description;
            Result.ColourCode = CreatePair(Message.colour).Code;
            Result.ColourDescription = CreatePair(Message.colour).Description;
            Result.DrivenCode = CreatePair(Message.driven).Code;
            Result.DrivenDescription = CreatePair(Message.driven).Description;
            Result.CategoryCode = CreatePair(Message.category).Code;
            Result.CategoryDescription = CreatePair(Message.category).Description;
            Result.DescriptionCode = CreatePair(Message.description).Code;
            Result.Description = CreatePair(Message.description).Description;
            Result.EconomicSectorCode = CreatePair(Message.economicSector).Code;
            Result.EconomicSectorDescription = CreatePair(Message.economicSector).Description;
            Result.LifeStatusCode = CreatePair(Message.lifeStatus).Code;
            Result.LifeStatusDescription = CreatePair(Message.lifeStatus).Description;
            Result.SapMarkCode = CreatePair(Message.sapMark).Code;
            Result.SapMarkDescription = CreatePair(Message.sapMark).Description;
            Result.HasIssues = (Message.ividQueryResult == IvidQueryResult.FURTHER_INVESTIGATION);
            Result.CarFullname = string.Format("{0} {1}", Result.MakeDescription, Result.ModelDescription);

            Result.SpecificInformation = new VehicleSpecificInformation()
            {
                Colour = Result.ColourDescription,
                RegistrationNumber = Result.Registration,
                VinNumber = Result.Vin,
                LicenseNumber = Result.License,
                EngineNumber = Result.Engine,
                Odometer = "Odometer Not Available",
                CategoryDescription = Result.CategoryDescription,
            };

            if (string.IsNullOrEmpty(Result.CarFullname))
            {
                Result.CarFullname = null;
            }
        }

        private const string NotAvailableError = "Error - Not Available";

        private string CheckPartialResults(string value)
        {
            if (Result.HasErrors && string.IsNullOrWhiteSpace(value))
            {
                value = NotAvailableError;
            }
            return value;
        }

        private static IvidWebResponsePair CreatePair(CodeDescription ividCodeDescription)
        {
            var pair = new IvidWebResponsePair(ividCodeDescription);
            pair.SetPairValues();
            return pair;
        }
    }

    internal class IvidWebResponsePair
    {
        public string Code { get; private set; }
        public string Description { get; private set; }

        private readonly CodeDescription _pair;

        public IvidWebResponsePair(CodeDescription pair)
        {
            _pair = pair;
            Code = string.Empty;
            Description = string.Empty;
        }

        public void SetPairValues()
        {
            if (_pair == null) return;

            Code = _pair.code;
            Description = _pair.description;
        }

    }


}
