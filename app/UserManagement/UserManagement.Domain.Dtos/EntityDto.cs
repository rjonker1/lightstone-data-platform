using System;

namespace UserManagement.Domain.Dtos
{
    public class EntityDto
    {
        public Guid Id { get; set; }
        public string Modified { get; set; }
        public string ModifiedBy { get; set; }
        public string Created { get; set; }
        public string CreatedBy { get; set; }
    }
}