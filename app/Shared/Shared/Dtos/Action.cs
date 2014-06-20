using System;

namespace DataPlatform.Shared.Dtos
{
    public class Action 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Criteria Criteria { get; set; }
    }
}