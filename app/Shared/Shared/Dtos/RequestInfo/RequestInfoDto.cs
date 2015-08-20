using System.Collections.Generic;

namespace DataPlatform.Shared.Dtos.RequestInfo
{
    public class RequestInfoDto
    {
        public IEnumerable<RequestInfoCustomerDto> Customers { get; set; }
    }
}