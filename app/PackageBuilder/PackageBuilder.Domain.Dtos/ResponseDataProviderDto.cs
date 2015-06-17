using System.Collections;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using PackageBuilder.Core.Entities;

namespace PackageBuilder.Domain.Dtos
{
    public class ResponseDataProviderDto
    {
        public DataProviderName Name { get; set; }
        public IEnumerable<ResponseDataFieldDto> DataFields { get; set; } 
    }
}