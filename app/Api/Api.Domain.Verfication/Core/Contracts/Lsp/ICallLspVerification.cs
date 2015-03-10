using Lace.Domain.Core.Requests.Contracts;

namespace Api.Domain.Verification.Core.Contracts.Lsp
{
    public interface ICallLspVerification
    {
        IHaveReturnPropertiesResponse PropertiesResponse(ILaceRequest request);
    }
}
