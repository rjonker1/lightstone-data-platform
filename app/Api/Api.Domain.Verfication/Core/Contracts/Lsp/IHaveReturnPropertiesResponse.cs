namespace Api.Domain.Verification.Core.Contracts.Lsp
{
    public interface IHaveReturnPropertiesResponse
    {
        IHaveReturnProperties ReturnProperties { get; }
        string Data { get; }
    }
}