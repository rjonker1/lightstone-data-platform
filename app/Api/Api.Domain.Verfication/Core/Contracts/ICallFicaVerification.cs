namespace Api.Domain.Verification.Core.Contracts
{
    public interface ICallFicaVerification
    {
        IHaveFicaVerficationResponse GetFicaInformationForPerson(IHaveFicaVerficationRequest request);
    }
}
