using System;

namespace Api.Domain.Infrastructure.Dto
{
    public class ApiRequestDto
    {
        public Guid ContractId { get; private set; }
        public Guid SourceId { get; private set; }
        public string SearchTerm { get; private set; }
        public string Username { get; set; }

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

    public class ApiPropertyRequest
    {
        public string TrackingNumber { get; private set; }
        public int MaxRowsToReturn { get; private set; }
        public string IdNumber { get; private set; }
        public Guid ContractId { get; private set; }
        public Guid SourceId { get; private set; }
        public string SearchTerm { get; private set; }
        public string Username { get; set; }

        public ApiPropertyRequest()
        {

        }

        public bool IsValid()
        {
            return ContractId != Guid.Empty && SourceId != Guid.Empty &&
                   !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(TrackingNumber) &&
                   !string.IsNullOrEmpty(IdNumber);
        }

        public ApiPropertyRequest(Guid contractId, Guid sourceId, string searchTerm, string username,
            string trackingNumber, int maxRowsToReturn, string idNumber)
        {
            TrackingNumber = trackingNumber;
            IdNumber = idNumber;
            MaxRowsToReturn = maxRowsToReturn;
            ContractId = contractId;
            SourceId = sourceId;
            SearchTerm = searchTerm;
            Username = username;
        }
    }
}
