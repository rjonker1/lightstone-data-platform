using System;

namespace Lim.Dtos
{
    public class DataFieldDto
    {
        public long Id { get; set; }
        public Guid DataSetId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool Selected { get; set; }
        public bool Activated { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
