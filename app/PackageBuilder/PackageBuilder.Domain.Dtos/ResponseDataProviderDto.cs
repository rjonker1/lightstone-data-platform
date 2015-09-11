using System.Collections.Generic;
using DataPlatform.Shared.Enums;

namespace PackageBuilder.Domain.Dtos
{
    public class ResponseDataProviderDto
    {
        public DataProviderName Name { get; set; }
        public IEnumerable<ResponseDataFieldDto> DataFields { get; set; } 
    }
}