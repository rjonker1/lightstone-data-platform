using System;

namespace Api.Domain.Verification.Core.Contracts.Lsp
{
    public interface IHaveLspPropertiesRequest
    {
        string ReturnPropertiesData { get; }
        
        string Username { get; }
        Guid UserId { get; }
    }
}