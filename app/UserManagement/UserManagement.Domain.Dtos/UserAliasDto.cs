using System;

namespace UserManagement.Domain.Dtos
{
    public class UserAliasDto
    {
        public string Id { get; set; }
        public string UuId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public Guid UserId { get; set; }  
        public Guid DefaultCustomerId { get; set; }  
        public string DefaultCustomerName { get; set; }  
        public Guid ClientId { get; set; }  
    }
}