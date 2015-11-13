using System;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromPCubedFicaVerfication : IPointToLaceProvider
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
}
