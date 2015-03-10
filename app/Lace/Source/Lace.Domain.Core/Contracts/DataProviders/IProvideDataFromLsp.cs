using Lace.Domain.Core.Contracts.DataProviders.DriversLicense;
using Lace.Domain.Core.Contracts.DataProviders.Lsp;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromLsp : IPointToLaceProvider
    {
        IRespondWithLspInformation LspInformation { get; }
        string Data { get; }
    }
}