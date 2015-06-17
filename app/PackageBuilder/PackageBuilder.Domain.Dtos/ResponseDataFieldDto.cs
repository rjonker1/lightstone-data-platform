using System.Collections.Generic;
using DataPlatform.Shared.Enums;

namespace PackageBuilder.Domain.Dtos
{
    public class ResponseDataFieldDto
    {
        public string Namespace { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
        public string Definition { get; set; }
        public int Order { get; set; }
        public string Type { get; set; }

        public IEnumerable<ResponseDataFieldDto> DataFields { get; set; }
    }
}