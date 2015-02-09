using System;

namespace UserManagement.Domain.Dtos
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string AccountOwnerName { get; set; }
        public Guid ProvinceId { get; set; }
    }
}