using DataPlatform.Shared.Enums;

namespace PackageBuilder.Domain.Dtos.Write
{
    public class DataProviderResponseDto
    {
        public DataProviderResponseState ResponseState { get; set; }
        public string ResponseStateMessage { get; set; }
    }
}
