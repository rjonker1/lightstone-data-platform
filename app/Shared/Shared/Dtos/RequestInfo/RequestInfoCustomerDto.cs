using System.Collections.Generic;

namespace DataPlatform.Shared.Dtos.RequestInfo
{
    public class RequestInfoCustomerDto : BaseRequestInfoDto
    {
        public IEnumerable<RequestInfoContractDto> Contracts { get; set; }
    }
}