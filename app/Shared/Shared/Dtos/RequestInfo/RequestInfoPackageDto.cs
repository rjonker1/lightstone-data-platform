using System.Collections.Generic;

namespace DataPlatform.Shared.Dtos.RequestInfo
{
    public class RequestInfoPackageDto : BaseRequestInfoDto
    {
        public IEnumerable<RequestInfoRequestFieldDto> RequestFields { get; set; }
    }
}