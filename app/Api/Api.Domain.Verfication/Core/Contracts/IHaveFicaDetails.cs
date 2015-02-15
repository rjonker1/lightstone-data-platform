using System;

namespace Api.Domain.Verification.Core.Contracts
{
    public interface IHaveFicaVerficationResponse
    {
        Guid TransactionToken { get; }
        long IdNumber { get; }
        string Initials { get; }
        string Surname { get; }
        string CellNumber { get; }
        string LifeStatus { get; }
        DateTime? DateOfBirth { get; }
        DateTime ResponseDate { get; }
    }

    public interface IHaveFicaVerficationRequest
    {
        long IdNumber { get; }
        string Username { get; }
        int FicaTransactionId { get; }
        Guid TransactionToken { get; }

        DateTime RequestDate { get; }
    }
}
