namespace Api.Verfication.Core.Contracts
{
    public interface ICallFicaVerification
    {
        IHaveFicaVerficationResponse GetFicaInformationForPerson(IHaveFicaVerficationRequest request);
    }
}
