using System;

namespace UserManagement.Domain.Dtos
{
    public class EntityDto
    {
        public DateTime? Modified { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? Created { get; set; }
        public string CreatedBy { get; set; }
    }
}