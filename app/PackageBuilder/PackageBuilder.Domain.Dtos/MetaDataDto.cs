using System.Collections.Generic;

namespace PackageBuilder.Domain.Dtos
{
    public class MetaDataDto
    {
        public string Route { get; set; }
        public IEnumerable<KeyValuePair<string, string>> RequestFields { get; set; }
        public IEnumerable<ResponseDataProviderDto> ResponseFields { get; set; }

        // Required for json serialization
        protected MetaDataDto() { }

        public MetaDataDto(string route, IEnumerable<KeyValuePair<string, string>> requestFields, IEnumerable<ResponseDataProviderDto> responseFields)
        {
            Route = route;
            RequestFields = requestFields;
            ResponseFields = responseFields;
        }
    }
}