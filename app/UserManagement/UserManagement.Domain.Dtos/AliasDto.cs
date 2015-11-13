using System;

namespace UserManagement.Domain.Dtos
{
    public class AliasDto
    {
        public Guid AliasId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid UserId { get; set; }
    }
}