using System;

namespace Api.Domain.Infrastructure.Dto
{
    public class ApiRequestDto
    {
        public Guid ContractId { get; private set; }
        public Guid SourceId { get; private set; }
        public string SearchTerm { get; private set; }

        public ApiRequestDto()
        {
            
        }

        public ApiRequestDto(Guid contractId, Guid sourceId, string searchTerm)
        {
            ContractId = contractId;
            SourceId = sourceId;
            SearchTerm = searchTerm;
        }
    }

}
