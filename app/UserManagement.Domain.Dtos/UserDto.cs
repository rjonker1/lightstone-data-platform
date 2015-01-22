using System;
using System.Collections.Generic;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Dtos
{
    public class UserDto
    {
        public DateTime FirstCreateDate { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public Guid UserTypeId { get; set; }
        public bool? IsActive { get; set; }
        public IEnumerable<ClientUser> ClientUser { get; set; }
        public UserType UserType { get; set; }
        public IEnumerable<UserLinkedToCustomer> UserLinkedToCustomer { get; set; }
        public IEnumerable<UserProfile> UserProfile { get; set; }
        public IEnumerable<UserRole> UserRole { get; set; } 
    }
}