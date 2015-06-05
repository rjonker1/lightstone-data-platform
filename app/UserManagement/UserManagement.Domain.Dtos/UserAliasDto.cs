using System.Collections.Generic;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Dtos
{
    public class UserAliasDto
    {
        public string UuId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public IEnumerable<User> Users { get; set; }  
    }
}