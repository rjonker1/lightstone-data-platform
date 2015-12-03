using System;
namespace Toolbox.LightstoneAuto.Database.Infrastructure.Dto
{
    public class TableDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool Activated { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}