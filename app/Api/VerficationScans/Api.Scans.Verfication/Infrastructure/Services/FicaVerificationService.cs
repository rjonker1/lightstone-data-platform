using System;
using Api.Scans.Verfication.Core.Contracts;
using Api.Scans.Verfication.Infrastructure.Dto;

namespace Api.Scans.Verfication.Infrastructure.Services
{
    public class FicaVerificationService : ICallFicaVerification
    {
        public FicaVerficationResponseDto GetFicaInformationForPerson(FicaVerficationRequestDto request)
        {
            //TODO: Call fica verfication data provider
            return new FicaVerficationResponseDto(8310245010082, request.TransactionToken, "R", "Jonker",
                "071896242", "Alive", DateTime.Now, DateTime.UtcNow);
        }
    }
}