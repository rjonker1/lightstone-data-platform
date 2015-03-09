using System.Dynamic;
using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.Lsp
{
    /// <summary>
    /// Output Data
    /// </summary>
    public interface IRespondWithLspInformation : IProvideType
    {
        IRespondWithReturnPropertiesRequestData RequestData { get; set; }
        IRespondWithReturnProperties Properties { get; set; }
    }
}
