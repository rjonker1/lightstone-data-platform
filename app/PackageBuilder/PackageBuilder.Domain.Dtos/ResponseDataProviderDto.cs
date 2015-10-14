using System.Collections.Generic;
using DataPlatform.Shared.Enums;

namespace PackageBuilder.Domain.Dtos
{
    public class ResponseDataProviderDto : IProvideResponseDataProvider
    {
        public DataProviderName Name { get; set; }
        //public string ResponseStateMessage { get; set; }
        public DataProviderResponseState ResponseState { get; set; }
        public IEnumerable<ResponseDataFieldDto> DataFields { get; set; } 
    }
}