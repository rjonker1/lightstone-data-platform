using System;

namespace Api.Domain.Infrastructure.Dto
{
    public class ApiRequestDto
    {
        public Guid ContractId { get; private set; }
        public Guid SourceId { get; private set; }
        public string SearchTerm { get; private set; }

        public string Username { get; private set; }

        public ApiRequestDto()
        {
            
        }

        public ApiRequestDto(Guid contractId, Guid sourceId, string searchTerm, string username)
        {
            ContractId = contractId;
            SourceId = sourceId;
            SearchTerm = searchTerm;
            Username = username;
        }

        public bool IsValid()
        {
            return ContractId != Guid.Empty && SourceId != Guid.Empty && !string.IsNullOrEmpty(SearchTerm) &&
                   !string.IsNullOrEmpty(Username);
        }
    }

}
