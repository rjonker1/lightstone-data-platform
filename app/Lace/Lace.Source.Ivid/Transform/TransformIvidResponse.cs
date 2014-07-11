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
            Result.SetErrorFlag(Message.partialResponse);

            Result.Build(Message.ividQueryResult.ToString(), Message.IvidReference, Message.licenceNumber,
                Message.registerNumber, Message.registrationDate, Message.vin, Message.engineNumber,
                Message.engineDisplacement, Message.tare);

            Result.SetMake(BuildIvidCodePair(Message.make));

            Result.SetModel(BuildIvidCodePair(Message.model));

            Result.SetColor(BuildIvidCodePair(Message.colour));

            Result.SetDriven(BuildIvidCodePair(Message.driven));

            Result.SetCategory(BuildIvidCodePair(Message.category));

            Result.SetDescription(BuildIvidCodePair(Message.description));

            Result.SetEconomicSector(BuildIvidCodePair(Message.economicSector));

            Result.SetLifeStatus(BuildIvidCodePair(Message.lifeStatus));

            Result.SetSapMark(BuildIvidCodePair(Message.sapMark));

            Result.SetHasIssuesFlag((Message.ividQueryResult == IvidQueryResult.FURTHER_INVESTIGATION));

            Result.BuildSpecificInformation();

            Result.SetCarFullName();
        }

        private static IvidCodePair BuildIvidCodePair(CodeDescription description)
        {
            return description == null
                ? new IvidCodePair(string.Empty, string.Empty)
                : new IvidCodePair(description.code, description.description);
        }
    }
}
