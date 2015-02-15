using System.Collections.Generic;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.Users
{
    public class CreateUser : DomainCommand
    {
        public string FirstName;
        public string LastName;
        public string IdNumber;
        public string ContactNumber;
        public string UserName;
        public string Password;
        public bool? IsActive;
        public UserType UserType;
        public HashSet<Role> Roles;

        public CreateUser(string firstName, string lastName, string idNumber, string contactNumber, string userName, string password, bool? isActive, UserType userType, HashSet<Role> roles)
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