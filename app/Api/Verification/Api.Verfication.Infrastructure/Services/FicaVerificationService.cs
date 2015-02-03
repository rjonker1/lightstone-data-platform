using System;
using Api.Verfication.Core.Contracts;
using Api.Verfication.Infrastructure.Dto;

namespace Api.Verfication.Infrastructure.Services
{
    public class FicaVerificationService : ICallFicaVerification
    {
        public IHaveFicaVerficationResponse GetFicaInformationForPerson(IHaveFicaVerficationRequest request)
        {
            //TODO: Call fica verfication data provider
            return new FicaVerficationResponseDto(8310245010082, request.TransactionToken, "R", "Jonker",
                "071896242", "Alive", DateTime.Now, DateTime.UtcNow);
        }
    }
}