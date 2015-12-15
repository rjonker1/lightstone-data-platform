using System;

namespace Lim.Dtos
{
    public class DatabaseExtractFieldDto
    {
        public long Id { get; set; }
        public long DatabaseExtractId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool Selected { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
