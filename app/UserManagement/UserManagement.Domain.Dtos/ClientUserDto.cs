using System;

namespace UserManagement.Domain.Dtos
{
    public class ClientUserDto
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public string ClientName { get; set; }
        public Guid UserId { get; set; }
        public string UserAlias { get; set; }
    }
}