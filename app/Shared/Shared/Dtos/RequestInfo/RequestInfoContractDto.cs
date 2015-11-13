using System.Collections.Generic;

namespace DataPlatform.Shared.Dtos.RequestInfo
{
    public class RequestInfoContractDto : BaseRequestInfoDto
    {
        public IEnumerable<RequestInfoPackageDto> Packages { get; set; }
    }
}