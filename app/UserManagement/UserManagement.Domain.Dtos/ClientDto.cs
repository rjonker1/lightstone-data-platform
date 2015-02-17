using System;

namespace UserManagement.Domain.Dtos
{
    public class ClientDto
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public ContactDetailDto ContactDetailDto { get; set; } 
    }
}