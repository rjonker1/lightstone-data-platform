using System;
using Api.Domain.Verification.Core.Contracts;
using Api.Domain.Verification.Infrastructure.Dto;

namespace Api.Domain.Verification.Infrastructure.Services
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