using System.Collections.Generic;

namespace DataPlatform.Shared.Dtos
{
    public class ApiMetaData
    {
        public string Path { get; set; }
        public IEnumerable<Action> Actions { get; set; }
    }
}