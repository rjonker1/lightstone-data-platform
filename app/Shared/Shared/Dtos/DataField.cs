using System;

namespace DataPlatform.Shared.Dtos
{
    public class DataField 
    {
        public string Type { get; set; }
        public DataSource DataSource { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}