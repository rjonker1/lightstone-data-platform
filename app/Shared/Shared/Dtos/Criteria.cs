using System.Collections.Generic;

namespace DataPlatform.Shared.Dtos
{
    public class Criteria 
    {
        public IEnumerable<DataFieldDto> Fields { get; set; }
    }
}