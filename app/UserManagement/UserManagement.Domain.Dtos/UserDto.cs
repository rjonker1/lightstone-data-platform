using System.Collections.Generic;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Dtos
{
    public class UserDto
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string IdNumber { get; set; }
        public virtual string ContactNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public UserType UserType { get; set; }
        public HashSet<Role> Roles { get; set; }

        public UserDto(string firstName, string lastName, string idNumber, string contactNumber, string userName, string password, bool? isActive, UserType userType, HashSet<Role> roles)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            ContactNumber = contactNumber;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            UserType = userType;
            Roles = roles;
        }
    }
}