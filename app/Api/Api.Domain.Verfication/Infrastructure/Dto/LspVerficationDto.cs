using System;
using Api.Domain.Verification.Core.Contracts.Lsp;

namespace Api.Domain.Verification.Infrastructure.Dto
{

    public class LspRequestDto : IHaveLspPropertiesRequest
    {
        public LspRequestDto()
        {
            
        }
        public LspRequestDto(string returnPropertiesData, string registrationCode,
            string username, Guid userId)
        {
            ReturnPropertiesData = returnPropertiesData;
            Username = username;
            UserId = userId;
        }

      
        public string ReturnPropertiesData { get; private set; }
        public string Username { get; private set; }
        public Guid UserId { get; private set; }
    }
}