using Api.Scans.Verfication.Infrastructure.Dto;

namespace Api.Scans.Verfication.Core.Contracts
{
    public interface ICallFicaVerification
    {
        FicaVerficationResponseDto GetFicaInformationForPerson(FicaVerficationRequestDto request);
    }
}
